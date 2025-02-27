using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    // Update is called once per frame

    public Transform InteractorSource;
    public float InteractorRange;
    
    public GameObject InteractorPrefab = null;
    
    void Update()
    {
        Debug.DrawRay(InteractorSource.position, InteractorSource.forward * InteractorRange, Color.green);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray,out RaycastHit hitInfo,InteractorRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObj))
                {
                    
                    if (hitInfo.collider.CompareTag("Meso") || hitInfo.collider.CompareTag("Prilog"))
                    {
                        if (InteractorPrefab == null)
                        {
                            InteractorPrefab = hitInfo.collider.gameObject;
                            interactableObj.Interact();
                        }
                    }
                    else
                    {
                        interactableObj.Interact();
                    }
                }
            }
        }       
    }
}
