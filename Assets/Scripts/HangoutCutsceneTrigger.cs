using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HangoutCutsceneTrigger : MonoBehaviour
{
    public UnityEvent playCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            playCutscene.Invoke();
        }
    }
}
