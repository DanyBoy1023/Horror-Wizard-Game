using UnityEngine;

public class SpiderAttackController : MonoBehaviour
{
    public float AttackDelay = 5;
    private float AttackDelayCounter = 0;
    public float AttackRange = 4;
    public float AttackSpeed;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= AttackRange)
        {
            if (AttackDelayCounter >= AttackDelay)
            {
                FirstPersonCharacterController fpsController = player.GetComponent<FirstPersonCharacterController>();
                fpsController.poison();
                AttackDelayCounter %= 0;
            }
            else
            {
                AttackDelayCounter += Time.deltaTime;
            }
        }
        else
        {
            AttackDelayCounter = 0;
        }
    }
}
