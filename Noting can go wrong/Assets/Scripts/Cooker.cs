using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    public Transform[] cookingPositoins;
    private bool[] areCookingPositoinsUsed;
    private GameObject[] cookingObjects;
    
    public Interactor Interactor;
    private int i = 0;
    
    public void Interact()
    {
        if (Interactor.InteractorPrefab != null && i<cookingPositoins.Length)
        {
            Interactor.InteractorPrefab.transform.position = cookingPositoins[i].position;
            Interactor.InteractorPrefab.transform.rotation = cookingPositoins[i].rotation;
            cookingObjects[i] = Interactor.InteractorPrefab;
            cookingObjects[i].GetComponent<MeatPickup>().isCooking = true;
            areCookingPositoinsUsed[i] = true;
            Interactor.InteractorPrefab = null;
            
            i++;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        cookingObjects = new GameObject[cookingPositoins.Length];
        areCookingPositoinsUsed = new bool[cookingPositoins.Length];
        
        for (int i = 0; i < areCookingPositoinsUsed.Length; i++)
        {
            areCookingPositoinsUsed[i] = false;
            cookingObjects[i] = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int j = 0; j < cookingPositoins.Length; j++)
        {
            if (other.gameObject == cookingObjects[j])
            {
                areCookingPositoinsUsed[j] = true;
                Debug.Log("stavljeno je " + j);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int j = 0; j < cookingPositoins.Length; j++)
        {
            if (other.gameObject == cookingObjects[j])
            {
                Debug.Log("skinuto je " + j);
                areCookingPositoinsUsed[j] = false;
                cookingObjects[j] = null;   

                if (j < i)
                {
                    i = j;
                }
                
            }
        }
    }
}

