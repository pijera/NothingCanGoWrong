using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostomerSpawning : MonoBehaviour
{

    public GameObject customer;
    public Transform spawnPoint;
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Costomer"))
        {
            Instantiate(customer, spawnPoint.position, spawnPoint.rotation);
        }
    }

   
}
