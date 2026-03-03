using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public float MoveSpeed;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = MoveSpeed;
        update_path();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        update_path();
    }

    void update_path()
    {
        navAgent.destination = player.transform.position;
    }
}
