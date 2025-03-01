using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour, IInteractable
{
    public Interactor interactor;
    public GameObject meat;
    
    public void Interact()
    {
        if (interactor.InteractorPrefab == null)
        {
            GameObject copy = Instantiate(meat,new Vector3(100,100,100),Quaternion.identity);
            interactor.InteractorPrefab = copy;
        }
    }
}
