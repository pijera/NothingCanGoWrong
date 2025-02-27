using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CustomerSystem : MonoBehaviour
{
    public Interactor Interactor;
    
    public CashRegister cashRegister;
    public Animator animator;

    public GameObject[] toppings;
    public GameObject burger;
    
    private List<string> orderToppings = new List<string>();
    private bool isOrderGenerated = false;

    public GameObject topBun;
    public GameObject bottomBun;
    public GameObject meat;

    void Awake()
    {
        Interactor = GameObject.Find("Player").GetComponent<Interactor>();
        cashRegister = GameObject.Find("Cash Register").GetComponent<CashRegister>();
    }
    
    
    void Update()
    {
        if (Interactor.InteractorPrefab!=null && Interactor.InteractorPrefab.name=="Burger")
        {
            burger = Interactor.InteractorPrefab;
            
            topBun = burger.transform.Find("TopBun").gameObject;
            bottomBun = burger.transform.Find("BottomBun").gameObject;
            meat = burger.transform.Find("Meat(Clone)").gameObject;

            if (topBun==null || bottomBun==null || meat==null)
            {
                Debug.Log("FALI TI NESTO RETARDE");
            }
        }
        
        if (!isOrderGenerated && animator.GetCurrentAnimatorStateInfo(0).IsName("CostomerToWait"))
        {
            Order();
            isOrderGenerated = true;
        }
        
        if (cashRegister.isGiven)
        {
            if (topBun!=null && bottomBun!=null && meat!=null)
            {
                if (CheckOrder())
                {
                    animator.SetTrigger("Paid");
                    
                }
            }
        }
    }

    public void Order()
    {
        orderToppings.Clear(); // Clear previous order

        int randomNumbOfToppings = UnityEngine.Random.Range(1, 4); // At least 1 topping

        for (int i = 0; i < randomNumbOfToppings; i++)
        {
            int randomToppingIndex = UnityEngine.Random.Range(0, toppings.Length);
            orderToppings.Add(toppings[randomToppingIndex].name+"(Clone)"); // Store the topping name
        }

        Debug.Log(GetOrderDescription());
    }

    public bool CheckOrder()
    {
        List<GameObject> burgerToppings = GetToppings();

        if (!MustHaveToppings())
        {
            Debug.Log("Nemas hleb ili meso.");
            return false;
        }

        if (burgerToppings.Count != orderToppings.Count)
        {
            Debug.Log("Ne tacan broj dodataka. Order: " + orderToppings.Count + ", Burger: " + burgerToppings.Count);
            return false;
        }

        // Compare topping names
        foreach (string toppingName in orderToppings)
        {
            bool found = false;
            foreach (GameObject topping in burgerToppings)
            {
                if (topping.name == toppingName)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Debug.Log("Fali ti: " + toppingName);
                return false;
            }
        }

        Debug.Log("Porudzbina je tacna!");
        return true;
    }
    private bool MustHaveToppings()
    {
        bool IsTopBun = false;
        bool IsBottomBun = false;
        bool IsMeat = false;

        foreach (Transform child in burger.transform)
        {
            if (child.gameObject == topBun) IsTopBun = true;
            if (child.gameObject == bottomBun) IsBottomBun = true;
            if (child.gameObject == meat) IsMeat = true;
        }
        
        if (IsTopBun && IsBottomBun && IsMeat)
        {
            return true;
        }
        return false;   
    }
    
    private List<GameObject> GetToppings()
    {
        List<GameObject> burgerToppings = new List<GameObject>();

        foreach (Transform child in burger.transform)
        {
            if (IsTopping(child.gameObject))
            {
                burgerToppings.Add(child.gameObject);
            }
        }
        return burgerToppings;
    }

    private bool IsTopping(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Object je null.");
            return false;
        }

        foreach (GameObject topping in toppings)
        {
            if (topping == null)
            {
                continue;
            }
            if (topping.name+"(Clone)" == obj.name)
            {
                return true;
            }
        }
        return false;
    }

    public string GetOrderDescription()
    {
        string description = "Porudzbina: ";
        for (int i = 0; i < orderToppings.Count; i++)
        {
            description += orderToppings[i];
            if (i < orderToppings.Count - 1)
            {
                description += ", ";
            }
        }
        return description;
    }

    public void Leave()
    {
        Destroy(gameObject);
    }
}
