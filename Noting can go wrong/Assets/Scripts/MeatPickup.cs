using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPickup : MonoBehaviour, IInteractable
{
    [HideInInspector]
    public bool pickedUp = false;
    public bool isCooking = false;
    
    public int cookingPercentage = 0;
    
    public Animator animator;
    private Coroutine cookingCoroutine;
    
    public Interactor interactor;
    
    public void Interact()
    {
            pickedUp = true;
            isCooking = false;
            gameObject.transform.position = new Vector3(100, 100, 100);
        

    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (isCooking == true && cookingCoroutine == null)
        {
            cookingCoroutine = StartCoroutine(Cook());
            animator.SetTrigger("StartCooking");
            animator.speed = 1;
        }
        else if (!isCooking && cookingCoroutine != null)
        {
            StopCoroutine(cookingCoroutine);
            animator.speed = 0;
            cookingCoroutine = null;
        }
    }

    IEnumerator Cook()
    {
        isCooking = true;
        while (cookingPercentage < 150 && isCooking == true)
        {
            yield return new WaitForSeconds(1.67f);
            cookingPercentage += 10;
            cookingPercentage = Mathf.Clamp(cookingPercentage, 0, 150);
        }
        isCooking = false;
    }

}
