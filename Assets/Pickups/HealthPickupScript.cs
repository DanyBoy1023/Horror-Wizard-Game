using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    public float HealAmount = 50;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonCharacterController fpsController = other.gameObject.GetComponent<FirstPersonCharacterController>();
            if (fpsController.hp < fpsController.maxHp)
            {
                other.gameObject.GetComponent<FirstPersonCharacterController>().heal(HealAmount);
                audioSource.Play();
                Destroy(gameObject);
            }
        }
    }
}
