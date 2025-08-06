using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 inputMovement = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    public float speed = 5;
    public float rotationSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        inputMovement.x = Input.GetAxis("Horizontal");
        inputMovement.z = Input.GetAxis("Vertical");

        inputMovement *= speed * Time.deltaTime;

        rotation.x += Input.GetAxis("Mouse X");
        //rotation.y += -Input.GetAxis("Mouse Y");

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(rotation), Time.deltaTime * rotationSpeed);

        transform.Translate(inputMovement.x, 0, inputMovement.z, Space.World);    
    }
}
