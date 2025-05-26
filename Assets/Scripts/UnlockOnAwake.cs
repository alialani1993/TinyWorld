using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockOnAwake : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = UnityEngine.CursorLockMode.None;
    }
}
