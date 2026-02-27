using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{

    private GameObject player;
    private FirstPersonCharacterController fpsController;

    public Slider hpSlider;
    public Slider StaminaSlider;
    public Slider FireballCooldownSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fpsController = player.GetComponent<FirstPersonCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBars();
    }

    public void UpdateBars()
    {
        hpSlider.value = fpsController.hp / fpsController.maxHp;
        StaminaSlider.value = fpsController.Stamina / fpsController.MaxStamina;

        FireballEmitter fireball = player.GetComponent<FireballEmitter>();
        FireballCooldownSlider.value = fireball.cooldownCounter / fireball.Cooldown;
    }
}
