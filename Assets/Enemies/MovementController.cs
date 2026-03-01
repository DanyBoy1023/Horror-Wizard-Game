using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public float MoveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = MoveSpeed;
        update_path();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        update_path();
    }

    void update_path()
    {
        navAgent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
