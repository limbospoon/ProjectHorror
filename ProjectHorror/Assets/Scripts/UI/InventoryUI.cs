using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : InventoryWindow
{
    public List<InventoryItem> inventoryItems;
    public List<InventoryUISlot> slots = new List<InventoryUISlot>();
    public InventoryManager inventoryManager;

    public GameObject slotsParent;
    public GameObject inventorySlot;

    private void Awake()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(inventorySlot, slotsParent.transform);
            go.name = "Slot " + i.ToString();
            go.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
            go.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(4.2f, (-18 + (i  * (-30))));
            slots.Add(go.GetComponent<InventoryUISlot>());
        }
    }

    public override void ToggleDisplay(bool show)
    {
        base.ToggleDisplay(show);
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        inventoryItems = inventoryManager.inventory;
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            slots[i].UpdateSlot(inventoryItems[i]);
        }
    }
}
