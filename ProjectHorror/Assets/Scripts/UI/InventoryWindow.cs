using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    public GameObject windowObject;
    public int windowID;

    public virtual void ToggleDisplay(bool show)
    {
        windowObject.SetActive(show);
    }
}
