using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TravelForwardToGoal : MonoBehaviour
{
    public Transform goal;
    
    [SerializeField] private float baseSpeed = 5;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float rotationSpeed = 4;
    [SerializeField] private float slowDownDistance = 10f;
    [SerializeField] private float acceleration = 3f;

    private float currentSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        this.transform.position.y, 
                                        goal.position.z);
        
        Vector3 direction = lookAtGoal - transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                Quaternion.LookRotation(direction), 
                                                Time.deltaTime * rotationSpeed);

        float distanceToGoal = Vector3.Distance(lookAtGoal, transform.position);
        
        if (distanceToGoal < slowDownDistance)
            currentSpeed -= (acceleration * (slowDownDistance / distanceToGoal)) * Time.deltaTime;
        else
            currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, baseSpeed, maxSpeed);

        Vector3 baseVelocity = Vector3.zero;
        Vector3 currentVelocity = new Vector3(0f, 0f, currentSpeed);

        currentVelocity = Vector3.Lerp(baseVelocity, 
                                    currentVelocity, 
                                    distanceToGoal);
        
        if (distanceToGoal > 1)
            transform.Translate(currentVelocity * Time.deltaTime);
    }
}
