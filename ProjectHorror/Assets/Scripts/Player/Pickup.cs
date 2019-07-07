using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public InventoryItem item;

    public override void Use()
    {
        HorrorCharacter hc = GameObject.Find("Player").GetComponent<HorrorCharacter>();
        PickupItem(hc);
    }

    void PickupItem(HorrorCharacter horrorCharacter)
    {
        horrorCharacter.PickupItem(item);
        Destroy(this.gameObject, 0.05f);
    }
}
