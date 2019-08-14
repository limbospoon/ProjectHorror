using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
