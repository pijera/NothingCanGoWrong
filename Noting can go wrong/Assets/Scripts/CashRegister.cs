using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour,IInteractable
{
    [HideInInspector]
    public bool isGiven = false;
    public void Interact()
    {
        isGiven = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
