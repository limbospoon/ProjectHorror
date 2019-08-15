using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    public List<InventoryUISlot> slots = new List<InventoryUISlot>();
    public List<Mesh> displayMeshes;
    public InventoryManager inventoryManager;
    public GameObject slotsParent;
    public GameObject inventorySlot;
    public GameObject windowObject;
    public int windowID;

    public InventoryItem currentItem;
    public MeshFilter currentDisplayObject;

    private void Awake()
    {    
        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(inventorySlot, slotsParent.transform);
            go.name = "Slot " + i.ToString();
            go.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1.0f);
            go.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1.0f);
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(4.2f, (-18 + (i * (-30))));
            go.GetComponent<InventoryUISlot>().inventoryWindow = this;
            slots.Add(go.GetComponent<InventoryUISlot>());
        }
    }

    public void ToggleDisplay(bool show)
    {
        windowObject.SetActive(show);
        UpdateInventoryUI();
    }

    void UpdateDisplayObject()
    {
        for(int i = 0; i < displayMeshes.Count; i++)
        {
            if(displayMeshes[i].name == currentItem.name)
            {
                currentDisplayObject.mesh = displayMeshes[i];
                break;
            }
        }
    }
    
    public void SetCurrentItem(InventoryItem item)
    {
        currentItem = item;
        UpdateDisplayObject();
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < inventoryManager.inventory.Count; i++)
        {
            slots[i].UpdateSlot(inventoryManager.inventory[i]);
        }
    }
}
