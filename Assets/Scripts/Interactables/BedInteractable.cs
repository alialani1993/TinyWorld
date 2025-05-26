using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BedInteractable : MonoBehaviour, IInteractable
{
    public PlayableDirector director;
    public PlayableAsset gotobedCutscene;
    public string GetInteractableText()
    {
        return "Go to Bed";
    }

    public void Interact()
    {
        director.Play(gotobedCutscene);
    }

    public void GoToFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

}
