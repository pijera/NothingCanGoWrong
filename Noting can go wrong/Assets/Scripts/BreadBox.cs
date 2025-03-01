using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BreadBox : MonoBehaviour,IInteractable
{
    public Interactor interactor;
    public GameObject burger;
    
    public void Interact()
    {
        Debug.Log("BreadBox Interact");
        if (interactor.InteractorPrefab == null)
        {
            GameObject copy = Instantiate(burger,new Vector3(100,100,100),quaternion.identity);
            interactor.InteractorPrefab = copy;
        }
    }
}
