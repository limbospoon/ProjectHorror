using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public InventoryItem item;

    private HorrorCharacter horrorCharacter; 

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

    void PickupItem()
    {
        horrorCharacter.InventoryManager.Add(item);
        horrorCharacter.interactable = null;
        Destroy(this.gameObject, 0.05f);
    }
}
