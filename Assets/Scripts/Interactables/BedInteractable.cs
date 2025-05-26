using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedInteractable : MonoBehaviour, IInteractable
{
    public string GetInteractableText()
    {
        return "Go to Bed";
    }

    public void Interact()
    {
        SceneManager.LoadScene(0);
    }

}
