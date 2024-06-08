using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLocker : MonoBehaviour
{
    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus) Cursor.lockState = CursorLockMode.Locked;
    }
}
