using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class FirstPersonCharacterController : MonoBehaviour
{
    public enum states
    {
        free,
        sprinting,
        crouching,
        dead
    }
    public Stack<states> PlayerStateStack = new Stack<states>();
    
    [Header("Movement")]
    public float WalkSpeed = 5F;
    public float SprintMultiplier = 2F;
    public float CrouchMultiplier = .7F;
    public float JumpForce = 5F;
    public float GroundCheckDistance = 1.5F;
    public float LookSensitivityX = 1F;
    public float LookSensitivityY = 1F;
    public float MinYLookAngle = -90F;
    public float MaxYLookAngle = 90F;
    public Transform PlayerCamera;
    public float Gravity = -9.8F;
    private Vector3 velocity;
    private float verticalRotation = 0;
    private CharacterController characterController;
    private bool jumped = false;
    private PlayerInput playerInput;
    private InputAction move;

    private InputAction sprint;
    public Slider StaminaSlider;
    public float MaxStamina = 100F;
    public float Stamina = 100F;
    public float StaminaDrain = 10F;
    public float StaminaFillSpeed = 10F;
    public float FillDelay = 2F;
    public bool Fatigued = false;
    public float FatigueThreshold = 30F;

    [Header("Health")]
    public Slider HpSlider;
    public float maxHp = 100;
    public float hp;
    public Text GameOverText;

    private void Start()
    {
        hp = maxHp;
        PlayerStateStack.Push(states.free);
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions.FindAction("Move");
        sprint = playerInput.actions.FindAction("Sprint");

        PlayerCamera.transform.rotation = new Quaternion(0,0,0,0);
    }

    public void damage(float value)
    {
        hp -= value;
        hp = Mathf.Clamp(hp, 0, maxHp);
        if (hp <=0)
        {
            PlayerStateStack.Push(states.dead);
            if (GameOverText != null)
            {
                GameOverText.enabled = true;
            }
        }
        HpSlider.value = hp / maxHp;
    }


    public states getCurrentState()
    {
        states currentState = PlayerStateStack.Peek();
        return currentState;
    }

    public bool isSprinting() { return getCurrentState() == states.sprinting; }
    public bool isCrouching() { return getCurrentState() == states.crouching; }

    private void Update()
    {
        if (getCurrentState() == states.dead)
        {
            return;
        }
        StaminaSlider.value = Stamina / MaxStamina;

        #region Horizontal movement
        Vector2 value = move.ReadValue<Vector2>();

        float horizontalMovement = value.x;
        float verticalMovement = value.y;

        Vector3 moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        moveDirection.Normalize();

        #region Sprinting and Stamina
        bool pressing_sprint_button = sprint.ReadValue<float>() == 1;
        if (pressing_sprint_button && !Fatigued && Stamina >= 0 && !isSprinting())
        {
            PlayerStateStack.Push(states.sprinting);
        } 
        else if (isSprinting())
        {
            if (moveDirection == Vector3.zero || Stamina == 0 || Fatigued)
            {
                PlayerStateStack.Pop();
            }
        }
        if (Stamina == 0)
        {
            Fatigued = true;
        }
        if (Stamina >= FatigueThreshold)
        {
            Fatigued = false;
        }


        float speed = WalkSpeed;
        if (isSprinting())
        {
            Stamina -= StaminaDrain * Time.deltaTime;
            speed *= SprintMultiplier;
        }
        else
        {
            Stamina += StaminaFillSpeed * Time.deltaTime;
        }
        Stamina = Mathf.Clamp(Stamina, 0, MaxStamina);
        #endregion
        
        //if (isCrouching())
        //{
        //    speed *= CrouchMultiplier;
        //    characterController.height = Mathf.Lerp(Col.height, CrouchHeight, SpeedToCrouch);
        //}
        //else
        //{
        //    characterController.height = Mathf.Lerp(Col.height, 2, SpeedToCrouch);
        //}
        //characterController.center = new Vector3(0, (2F - Col.height) / 2F, 0);
        //Col.height = characterController.height;
        //Col.center = characterController.center;

        characterController.Move(moveDirection * speed * Time.deltaTime);
        #endregion

        if (jumped) { jumped = false; }
        else if (!IsGrounded())
        {
            velocity.y += Gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);
    }

    public void OnLook(InputValue value)
    {
        if (getCurrentState() == states.dead)
        {
            return;
        }
        Vector2 dir = value.Get<Vector2>();

        float mouseX = dir.x * LookSensitivityX;
        float mouseY = dir.y * LookSensitivityY;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, MinYLookAngle, MaxYLookAngle);

        PlayerCamera.localRotation = Quaternion.Euler(verticalRotation, 0F, 0F);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && IsGrounded())
        {
            velocity.y = JumpForce;
            jumped = true;
        }
    }

    public void OnCrouch(InputValue value)
    {
        if (value.isPressed)
        {
            if (!isCrouching())
            {
                if (isSprinting())
                {
                    PlayerStateStack.Pop();
                    PlayerStateStack.Push(states.crouching);
                }
                else
                {
                    PlayerStateStack.Push(states.crouching);
                }
            }
            else
            {
                PlayerStateStack.Pop();
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        bool isGrounded = false;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, GroundCheckDistance))
        {
            isGrounded = true;
        }
        return isGrounded;
    }
}
