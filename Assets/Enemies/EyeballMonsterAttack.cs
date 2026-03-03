using UnityEngine;

public class EyeballMonsterAttack : MonoBehaviour
{

    public Transform ShootingPoint;
    public GameObject BulletPrefab;
    public float BulletSpeed = 5;
    public float ShotDelay = 10;
    private float ShotCounter = 0;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (ShotCounter >= ShotDelay)
        {
            Shoot();
            ShotCounter = 0;
        }
        else
        {
            ShotCounter += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab);

        bullet.transform.position = ShootingPoint.position;

        bullet.transform.LookAt(player.GetComponent<FirstPersonCharacterController>().PlayerCamera);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bullet.transform.forward.normalized * BulletSpeed;
    }
}
