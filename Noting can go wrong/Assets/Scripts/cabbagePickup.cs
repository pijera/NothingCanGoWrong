using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabbagePickup : MonoBehaviour,IInteractable
{
    
    public Interactor Interactor;
    public void Interact()
    {
        if (Interactor.InteractorPrefab != null)
        {
            Interactor.InteractorPrefab = null;
        }
        else
        {
            Interactor.InteractorPrefab = gameObject;
            gameObject.transform.position = new Vector3(100, 100, 100);
        }
    }
}
