using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TalkInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent chatEvent;
    public string GetInteractableText()
    {
        return "Chat";
    }

    public void Interact()
    {
        chatEvent.Invoke();
    }

}
