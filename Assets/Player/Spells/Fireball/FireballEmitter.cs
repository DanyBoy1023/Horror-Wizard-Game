using UnityEngine;
using UnityEngine.InputSystem;

public class FireballEmitter : MonoBehaviour
{
    public GameObject BulletPrefab;
    private PlayerInput playerInput;
    private InputAction BasicAttack;
    private PlayerSpellController spellController;
    public float Cooldown = 5;
    public float cooldownCounter;
    public float blastRadius = 10;
    public float BulletSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        BasicAttack = playerInput.actions.FindAction("Fireball");
        spellController = GetComponent<PlayerSpellController>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        bool attacking = BasicAttack.ReadValue<float>() == 1f;

        if (attacking)
        {
            if (cooldownCounter >= Cooldown)
            {
                shoot();
            }
        }
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab);
        GameObject rightHand = spellController.RightHand;

        bullet.transform.position = rightHand.transform.position;
        bullet.transform.rotation = rightHand.transform.rotation;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bullet.transform.forward.normalized * BulletSpeed;
    }

    public void OnFireball(InputValue value)
    {
        Debug.Log(value.ToString());
        if (value.isPressed)
        {
            
        }
    }
}
