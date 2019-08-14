using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : InventoryWindow
{
    public List<InventoryItem> inventoryItems;
    public 
    public InventoryManager inventoryManager;

    public override void ToggleDisplay(bool show)
    {
        base.ToggleDisplay(show);
        inventoryItems = inventoryManager.inventory;
    }
}
