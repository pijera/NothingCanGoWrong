using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour,IInteractable
{
    public Interactor interactor;
    
    public void Interact()
    {
        if (interactor.InteractorPrefab != null)
        {
            Destroy(interactor.InteractorPrefab);
            interactor.InteractorPrefab = null;
        }
    }
}
