using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public GameObject FireballExplosionPrefab;
    public float damage;
    public float screenshakeDuration = .2f;
    public float screenshakeAmount = 5;
    public float screenshakeDiminish = .2f;
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
        GameObject player = GameObject.FindWithTag("Player");
        FirstPersonCharacterController fpsController = player.GetComponent<FirstPersonCharacterController>();
        fpsController.PlayerCamera.gameObject.GetComponent<CameraShake>().shakecamera(screenshakeDuration, screenshakeAmount, screenshakeDiminish);
    }
}
