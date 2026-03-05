using UnityEngine;

public class EyeballMonsterBulletController : MonoBehaviour
{
    public float Damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            FirstPersonCharacterController player = collision.gameObject.GetComponent<FirstPersonCharacterController>();
            player.damage(Damage);
        }
        Destroy(gameObject);
    }
}
