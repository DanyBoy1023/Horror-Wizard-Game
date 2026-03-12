using UnityEngine;

public class SpiderAttackController : MonoBehaviour
{
    public Animator anim;
    public float AttackDelay = 5f;
    private float AttackDelayCounter = 0;
    public float AttackRange = 4;
    public float AttackSpeed;

    private GameObject player;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= AttackRange)
        {
            anim.SetBool("Attacking", true);
            if (AttackDelayCounter >= AttackDelay)
            {
                FirstPersonCharacterController fpsController = player.GetComponent<FirstPersonCharacterController>();
                fpsController.poison();
                audioSource.Play();
                AttackDelayCounter %= 0;
            }
            else
            {
                AttackDelayCounter += Time.deltaTime;
            }
        }
        else
        {
            anim.SetBool("Attacking", false);
            AttackDelayCounter = AttackDelay;
        }
    }
}
