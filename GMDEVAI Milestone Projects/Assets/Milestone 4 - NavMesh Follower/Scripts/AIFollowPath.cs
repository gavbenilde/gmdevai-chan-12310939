using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPath : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject wpManager;
    GameObject[] wps;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    public void GoToWaypoint(int index)
    {
        // graph.AStar(currentNode, wps[index]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[0].transform.position);
    }
}
