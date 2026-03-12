using UnityEngine;

public class FireballExplosion : SpellHitDetection
{
    public float duration = .3f;
    private float durationCounter = 0;
    public GameObject ExplosionSoundPrefab;
    
    private void Start()
    {
        GameObject ExplosionSoundObject = Instantiate(ExplosionSoundPrefab);
        ExplosionSoundObject.transform.SetParent(transform.parent);
        ExplosionSoundObject.transform.position = transform.position;
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
}
