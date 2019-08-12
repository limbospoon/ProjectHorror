using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryScreen;

    public void ToggleDisplay(bool show)
    {
        inventoryScreen.SetActive(show);
    }
}
