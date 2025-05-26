using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent showCredits;
    public string GetInteractableText()
    {
        return "Show Credits";
    }

    public void Interact()
    {
        showCredits.Invoke();
    }

}
