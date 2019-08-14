using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public void Add(InventoryItem item)
    {
        inventory.Add(item);
    }
    
    public void AddDummyItem()
    {
        InventoryItem i = new InventoryItem();
        i.name = "Dummy";
        i.count = 1;
        i.canEquip = false;
        Add(i);
    }
}
