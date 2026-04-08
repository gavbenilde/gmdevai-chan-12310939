using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 inputMovement = Vector3.zero;
    private Quaternion rotation = Quaternion.identity;

    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 4;

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
        transform.Translate(inputMovement.x, 0, inputMovement.z);
        
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        rotation.y += mouseX;

        Quaternion targetRotation = Quaternion.Euler(0f, rotation.y, 0f);
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                    targetRotation, 
                                                    rotationSpeed * Time.deltaTime);
    }
}
