using UnityEngine;

public class FireballExplosion : SpellHitDetection
{
    public float duration = .3f;
    private float durationCounter = 0;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (durationCounter >= duration)
        {
            Destroy(gameObject);
        }
        else
        {
            durationCounter += Time.deltaTime;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        HitTrigger hitTrigger = other.gameObject.GetComponent<HitTrigger>();

        if (hitTrigger != null)
        {
            hitTrigger.Hit(Damage, status);
        }
    }
    public new void OnCollisionEnter(Collision collision)
    {
        // do nothing
    }
}
