using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyMovementController : MonoBehaviour
{
    public enum EnemyStates
    {
        Wandering,
        Chasing
    }
    public EnemyStates State = EnemyStates.Wandering;
    public float MoveSpeed = 1;
    public float WanderingDelay = 4;
    private float WanderingCounter = 0;
    public float WanderingDistance = 5;
    public float VisibilityDistance = 10;
    public float NavigationUpdateDelay = 3;
    private Vector3 WanderingPos;
    private NavMeshAgent navAgent;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == EnemyStates.Wandering)
        {
            // If the enemy is wandering, raycast at a random rotation, then check if there's something there
            if (!navAgent.pathPending)
            {
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                    {
                        if (WanderingCounter >= WanderingDelay)
                        {
                            WanderingCounter = 0;
                            WanderingPos = RandomNavSphere(transform.position, WanderingDistance, -1);
                            navAgent.destination = WanderingPos;
                        }
                        else
                        {
                            WanderingCounter += Time.deltaTime;
                        }
                    }
                }
            }

        }
        else if (State == EnemyStates.Chasing)
        {
            transform.LookAt(player.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            update_path();
        }

        // Update wandering or chasing state
        // Make a raycast in the direction of the player and check if it's in range. if it is, switch to chasing mode

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out hit, VisibilityDistance, -1))
        {
            if (hit.collider.CompareTag("Player"))
            {
                State = EnemyStates.Chasing;
            }
        }
    }

    void update_path()
    {
        navAgent.destination = player.transform.position;
    }

    public Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;
        int TotalTries = 1000;
        while (!NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask) && TotalTries > 0)
        {
            TotalTries--;
            randomDirection = Random.insideUnitSphere * distance;

            randomDirection += origin;
        }
        if (TotalTries <= 0)
        {
            return transform.position;
        }

        return navHit.position;
    }
}
