using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DelayText : MonoBehaviour
{
    public TMP_Text text;

    public void Awake()
    {
        StartCoroutine(DelayTextCoroutine());
    }

    public IEnumerator DelayTextCoroutine()
    {
        text.text = "Objective: Hang out with your friends";
        yield return new WaitForSeconds(60f);
        text.text = "Objective: Go to bed";
    }
}
