using UnityEngine;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Controller = GetComponent<BasicEnemyMovementController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.State == BasicEnemyMovementController.EnemyStates.Chasing)
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
}
