using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject angelPrefab;
    GameObject[] agents;
    
    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(monsterPrefab, hit.point, monsterPrefab.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControlCrowd>().DetectNewObstacle(hit.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(angelPrefab, hit.point, angelPrefab.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControlCrowd>().DetectNewPursuit(hit.point);
                }
            }
        }
    }
}
