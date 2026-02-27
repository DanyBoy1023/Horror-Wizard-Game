using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public GameObject FireballExplosionPrefab;
    public float damage;
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
        
        GameObject FireballExplosion = Instantiate(FireballExplosionPrefab, transform.parent);
        FireballExplosion.transform.position = transform.position;

        Destroy(gameObject);
    }
}
