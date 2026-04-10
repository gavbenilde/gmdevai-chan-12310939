using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    GameObject[] agents;
    public Camera camera;
    
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI"); 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ai in agents)
        {
            NavMeshAgent agent = ai.GetComponent<AIControlCapsule>().agent;
            
            if (Vector3.Distance(player.transform.position, agent.transform.position) < 5.0f)
            {
                agent.velocity = Vector3.zero;
            }
            
            agent.SetDestination(player.transform.position);
        }
    }
}
