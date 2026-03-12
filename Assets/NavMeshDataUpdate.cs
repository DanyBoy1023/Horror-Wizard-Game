using Unity.AI.Navigation;
using UnityEngine;
using System.Collections;

public class NavMeshDataUpdate : MonoBehaviour
{
    private NavMeshSurface navData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navData = GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMeshData()
    {
        StartCoroutine(DelayedAction());
    }

    IEnumerator DelayedAction()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(.1f);

        // Code here will execute after the 3-second wait
        navData.UpdateNavMesh(navData.navMeshData);
    }
}
