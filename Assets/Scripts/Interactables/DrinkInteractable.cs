using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrinkInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent drink;
    public string GetInteractableText()
    {
        return "Drink";
    }

    public void Interact()
    {
        drink.Invoke();
    }

   
}
