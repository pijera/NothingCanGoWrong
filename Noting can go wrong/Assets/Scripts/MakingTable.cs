using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingTable : MonoBehaviour,IInteractable
{
    public Interactor interactor;
    public Transform placementTransform;
    
    private GameObject currentBurger;
    public void Interact()
    {
        // Check if the player is holding something
        if (interactor.InteractorPrefab != null)
        {
            // If the player is holding a burger, place it on the table
            if (interactor.InteractorPrefab.CompareTag("Burger"))
            {
                currentBurger = interactor.InteractorPrefab;
                currentBurger.transform.position = placementTransform.position;
                currentBurger.transform.rotation = placementTransform.rotation;
                currentBurger.transform.SetParent(placementTransform);

                interactor.InteractorPrefab = null;
                Debug.Log("Burger placed on the table.");
            }
            // If the player is holding an ingredient, add it to the burger
            else if (currentBurger != null)
            {
                Burger burgerScript = currentBurger.GetComponent<Burger>();
                if (burgerScript != null)
                {
                    GameObject copy = Instantiate(interactor.InteractorPrefab);
                    burgerScript.AddIngredient(copy);

                    interactor.InteractorPrefab = null;
                    Debug.Log("Ingredient added to the burger.");
                }
            }
            else
            {
                Debug.Log("No burger on the table to add ingredients to.");
            }
        }
        else
        {
            Debug.Log("Player is not holding anything.");
        }
    }
}
