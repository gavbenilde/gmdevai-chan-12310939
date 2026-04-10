using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIControlCapsule : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    
    void Start()
    {
        this.agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}