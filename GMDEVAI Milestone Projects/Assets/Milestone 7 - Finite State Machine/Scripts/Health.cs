using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float health = 100;
    
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            TriggerDeath();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hit!");
            
            this.health -= 10f;
        }
    }

    void TriggerDeath()
    {
        Destroy(this.gameObject);
    }

    public float GetHealth()
    {
        return health;
    }
}
