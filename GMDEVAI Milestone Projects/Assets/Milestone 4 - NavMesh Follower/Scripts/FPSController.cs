using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSController : MonoBehaviour
{
    public GameObject player;
    private Vector3 inputMovement = Vector3.zero;
    public float speed = 6f;
    public float rotSpeed = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleMouseLook();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotSpeed * 100f * Time.deltaTime;
        
        player.transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        inputMovement.x = Input.GetAxis("Horizontal");
        inputMovement.z = Input.GetAxis("Vertical");

        inputMovement *= speed * Time.deltaTime;
        transform.Translate(inputMovement.x, 0, inputMovement.z);

        Vector3 velocity = new Vector3(inputMovement.x, 0, inputMovement.z);
        
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;
    }
}