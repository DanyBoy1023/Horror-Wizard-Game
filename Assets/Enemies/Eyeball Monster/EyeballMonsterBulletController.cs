using UnityEngine;

public class EyeballMonsterBulletController : MonoBehaviour
{
    public float Damage = 10;
    
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
