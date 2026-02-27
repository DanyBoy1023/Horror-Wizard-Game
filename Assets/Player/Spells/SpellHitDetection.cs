using UnityEngine;

public class SpellHitDetection : MonoBehaviour
{
    public enum StatusTypes
    {
        None,
        Fire,
        Ice,
        Electric,
        Dark
    }
    public float Damage = 2;
    public StatusTypes status = StatusTypes.None;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        HitTrigger hitTrigger = collision.gameObject.GetComponent<HitTrigger>();
        
        if (hitTrigger != null)
        {
            hitTrigger.Hit(Damage, status);
        }
        Destroy(gameObject);
    }
}
