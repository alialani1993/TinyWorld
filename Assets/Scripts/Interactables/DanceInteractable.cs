using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DanceInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent makeDance;

    public string GetInteractableText()
    {
        return "Dance";
    }

    public void Interact()
    {
        makeDance.Invoke();
    }


}
