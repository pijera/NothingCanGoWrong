using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour, IInteractable
{

    public GameObject topBun;
    public GameObject bottomBun;
    
    private List<GameObject> ingredients = new List<GameObject>();
    
    public Interactor interactor;
    
    public void Interact()
    {
        if (interactor.InteractorPrefab != null)
        {
            AddIngredient(interactor.InteractorPrefab);
            gameObject.GetComponent<BoxCollider>().size += new Vector3(0,interactor.InteractorPrefab.transform.localScale.y,0);
            interactor.InteractorPrefab = null;
        }
        else
        {
            interactor.InteractorPrefab = gameObject;
            gameObject.transform.position = new Vector3(100, 100, 100);
        }
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ingredients.Add(topBun);
        ingredients.Add(bottomBun);
        
        PositionIngredients();
    }

    public void AddIngredient(GameObject ingredient)
    {
        ingredients.Insert(1, ingredient);
        ingredient.transform.SetParent(transform);
        PositionIngredients();   
    }
    
    private void PositionIngredients()
    {
        float currentHeight = 0f;

        for (int i = 0; i < ingredients.Count; i++)
        {
            float interactHeight = ingredients[i].GetComponent<Renderer>().bounds.size.y;
            ingredients[i].transform.localPosition = new Vector3(0, currentHeight, 0);
            currentHeight += interactHeight;
        }
    }
    
}