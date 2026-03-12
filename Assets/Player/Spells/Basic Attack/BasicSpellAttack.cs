using UnityEngine;
using UnityEngine.InputSystem;
using static FirstPersonCharacterController;

public class BasicSpellAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    private PlayerInput playerInput;
    private InputAction BasicAttack;
    public float ShotDelay = .1F;
    private float delayCounter = 0;
    private PlayerSpellController spellController;
    public float BulletSpeed = 5;
    public FirstPersonCharacterController fpscontroller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        BasicAttack = playerInput.actions.FindAction("Attack");
        spellController = GetComponent<PlayerSpellController>();
        fpscontroller = GetComponent<FirstPersonCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fpscontroller.getCurrentState() == states.dead || fpscontroller.getCurrentState() == states.locked)
        {
            return;
        }
        float delta = Time.deltaTime;
        bool attacking = BasicAttack.ReadValue<float>() == 1f;
        
        if (attacking)
        {
            if (delayCounter <= 0)
            {
                shoot();
                delayCounter += ShotDelay;
            }
            else
            {
                delayCounter -= delta;
            }
        }
    }

    public LayerMask layerMask;
    private void shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab);
        GameObject rightHand = spellController.RightHand;

        bullet.transform.position = rightHand.transform.position;
        bullet.transform.rotation = rightHand.transform.rotation;
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        FirstPersonCharacterController controller = GetComponent<FirstPersonCharacterController>();
        Transform playerCamera = controller.PlayerCamera;
        if (Physics.Raycast(playerCamera.position,  playerCamera.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            bullet.transform.LookAt(hit.point);
        }

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bullet.transform.forward.normalized * BulletSpeed;
    }
}
