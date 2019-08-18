using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    private int currentInventorySize = 0;

    private void Start()
    {
        //Debug.Log(inventory.Count);
    }

    public void Add(InventoryItem item)
    {
        if(inventory.Count > 0)
        {
            bool haveItem = false;
            for (int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].name == item.name)
                {
                    InventoryItem tmpItem = inventory[i];
                    tmpItem.count++;
                    item = tmpItem;
                    inventory[i] = item;
                    haveItem = true;
                    break;
                }
            }

            if(!haveItem)
            {
                inventory.Add(item);
            }
        }
        else
        {
            inventory.Add(item);
        }

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
