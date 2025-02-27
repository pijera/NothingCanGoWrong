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
            GameObject copy = gameObject;
            Interactor.InteractorPrefab = copy;
        }
    }
}
