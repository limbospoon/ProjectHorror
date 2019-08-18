using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public InventoryItem item;

    private HorrorCharacter horrorCharacter;

    private void Start()
    {
        item.name = "Bath";
        item.count = 1;
        item.canEquip = false;
        item.itemClass = new CandleItem();
    }

    public override void Use()
    {
        PickupItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HorrorCharacter>().interactable = this;
            horrorCharacter = other.GetComponent<HorrorCharacter>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HorrorCharacter>().interactable = null;
            horrorCharacter = null;
        }
    }

    void PickupItem()
    {
        horrorCharacter.InventoryManager.Add(item);
        horrorCharacter.interactable = null;
        Destroy(this.gameObject, 0.05f);
    }
}
