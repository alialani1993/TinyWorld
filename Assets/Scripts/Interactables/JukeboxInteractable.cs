using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JukeboxInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent pressButton;
    public void Interact()
    {
        pressButton.Invoke();
    }
}
