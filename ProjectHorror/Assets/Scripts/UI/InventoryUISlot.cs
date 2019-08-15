﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUISlot : MonoBehaviour
{
    public InventoryItem item;
    public Text slotText;

    private void Awake()
    {
        slotText = transform.GetChild(0).GetComponent<Text>();
        slotText.text = " ";
    }

    public void UpdateSlot(InventoryItem item)
    {
        this.item = item;
        slotText.text = this.item.name + " x" + this.item.count.ToString();
    }
}
