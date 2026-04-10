using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;

    public GameObject bullet;
    public GameObject turret;
    
    Health health;
    
    public GameObject GetPlayer()
    {
        return player;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        health = this.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            anim.SetFloat("distance", 100f);
            return;
        }
        
        anim.SetFloat("health", health.GetHealth());
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
    }
    
    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        
        Collider bulletCol = b.GetComponent<Collider>();
        Collider tankCol = GetComponent<Collider>();

        Physics.IgnoreCollision(bulletCol, tankCol);
        
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }
}
