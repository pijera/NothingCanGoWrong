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
    
    private List<GameObject> orderToppings = new List<GameObject>();
    private bool isOrderGenerated = false;

    public GameObject topBun;
    public GameObject bottomBun;
    public GameObject meat;
    void Update()
    {
        if (Interactor.InteractorPrefab!=null && Interactor.InteractorPrefab.name=="Burger")
        {
            burger = Interactor.InteractorPrefab;
            
            topBun = burger.transform.Find("TopBun").gameObject;
            bottomBun = burger.transform.Find("BottomBun").gameObject;
            meat = burger.transform.Find("Meat").gameObject;

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
        int randomNumbOfToppings = UnityEngine.Random.Range(0, 3);

        for (int i = 0; i < randomNumbOfToppings; i++)
        {
            int randomToppingIndex = UnityEngine.Random.Range(0, toppings.Length);
            orderToppings.Add(toppings[randomToppingIndex]);
           
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
            Debug.Log("Ne tacan broj dodataka.");
            return false;
        }

        foreach (GameObject topping in orderToppings)
        {
            if (!burgerToppings.Contains(topping))
            {
                Debug.Log("Fali ti:  " + topping.name);
                return false;
            }
        }

        foreach (GameObject topping in burgerToppings)
        {
            if (!orderToppings.Contains(topping))
            {
                Debug.Log("Visak je: " + topping.name);
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
        foreach (GameObject topping in toppings)
        {
            if (topping == null)
            {
                Debug.LogWarning("Topping in toppings array is null.");
                continue;
            }
            if (topping == obj)
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
            description += orderToppings[i].name;
            if (i < orderToppings.Count - 1)
            {
                description += ", ";
            }
        }
        return description;
    }
}
