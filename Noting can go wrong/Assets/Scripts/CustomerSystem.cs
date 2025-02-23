using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    
    public CashRegister cashRegister;
    public Animator animator;

    public GameObject[] toppings;
    
    // Update is called once per frame
    void Update()
    {
        if (cashRegister.isGiven == true)
        {
            animator.SetTrigger("Paid");
        }
    }

    public void Order()
    {
        
    }
    
}
