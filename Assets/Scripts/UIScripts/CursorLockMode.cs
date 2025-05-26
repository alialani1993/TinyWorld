using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorLockMode : MonoBehaviour
{
    public void Off()
    {
        Cursor.lockState = UnityEngine.CursorLockMode.None;
    }


    public void On()
    {
        Cursor.lockState = UnityEngine.CursorLockMode.Locked;
    }
}
