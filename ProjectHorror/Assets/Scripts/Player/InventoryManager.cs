using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    private int currentInventorySize = 0;

    public void Add(InventoryItem item)
    {
        inventory.Add(item);
    }
    
    public void AddDummyItem()
    {
        if(currentInventorySize < 20)
        {
            InventoryItem i = new InventoryItem();
            i.name = "Dummy";
            i.count = 1;
            i.canEquip = false;
            Add(i);
            currentInventorySize++;
        }
        else
        {
            Debug.Log("Inventory full!!");
        }
    }
}
