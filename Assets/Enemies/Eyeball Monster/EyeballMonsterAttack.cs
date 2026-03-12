using UnityEngine;
using static BasicEnemyMovementController;

public class EyeballMonsterAttack : MonoBehaviour
{

    public Transform ShootingPoint;
    public GameObject BulletPrefab;
    public float BulletSpeed = 5;
    public float Damage = 10;
    public float ShotDelay = 10;
    private float ShotCounter = 0;
    private GameObject player;
    private BasicEnemyMovementController Controller;
    private Animator anim;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Controller = GetComponent<BasicEnemyMovementController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool canSeePlayer = false;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out hit, Mathf.Infinity, -1))
        {
            if (hit.collider.CompareTag("Player"))
            {
                canSeePlayer = true;
            }
        }

        if (canSeePlayer && Controller.State == BasicEnemyMovementController.EnemyStates.Chasing)
        {
            if (ShotCounter >= ShotDelay)
            {
                anim.SetBool("Shooting", true);
                ShotCounter = 0;
            }
            else
            {
                ShotCounter += Time.deltaTime;
            }
        }
        
    }

    public void Shoot()
    {
        anim.SetBool("Shooting", false);
        GameObject bullet = Instantiate(BulletPrefab);

        bullet.transform.position = ShootingPoint.position;

        bullet.transform.LookAt(player.GetComponent<FirstPersonCharacterController>().PlayerCamera);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bullet.transform.forward.normalized * BulletSpeed;

        EyeballMonsterBulletController bulletController = bullet.GetComponent<EyeballMonsterBulletController>();
        bulletController.Damage = Damage;
    }

    public void PlaySound()
    {
        audioSource.pitch = -1;
        audioSource.timeSamples = audioSource.clip.samples - 1;
        audioSource.Play();
    }
}
