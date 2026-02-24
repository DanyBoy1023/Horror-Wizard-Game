using UnityEngine;
using UnityEngine.InputSystem;

public class BasicSpellAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction BasicAttack;
    public float ShotDelay = .1F;
    private float delayCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        BasicAttack = playerInput.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        float attacking = BasicAttack.ReadValue<float>();

    }

    private void shoot()
    {

    }
}
