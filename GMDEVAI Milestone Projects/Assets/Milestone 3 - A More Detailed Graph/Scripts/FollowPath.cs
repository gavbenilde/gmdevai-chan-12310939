using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex;
    Graph graph;
    
    public bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isActive) return;
        
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
            return;
        
        // the node we are closest to at the moment
        currentNode = graph.getPathPoint(currentWaypointIndex);

        // if we are close enough to the current waypoint, move to the next one
        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position, 
                            transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        // IF WE ARE NOT AT THE END OF THE PATH
        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction =  lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction), 
                                                    rotSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
    
    public void GoToWaypoint(int index)
    {
        graph.AStar(currentNode, wps[index]);
        currentWaypointIndex = 0;
    }
}
