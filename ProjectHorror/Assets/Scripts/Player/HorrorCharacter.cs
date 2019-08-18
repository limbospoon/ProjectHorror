﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(CharacterController))]
public class HorrorCharacter : MonoBehaviour
{
    public Interactable interactable;
    public Transform attachPoint;
    
    private InventoryManager inventoryManager;
    private Equipable equipable;

    public InventoryManager InventoryManager
    {
        get
        {
            return inventoryManager;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.LockCursor();

        if(!GetComponent<InventoryManager>())
        {
            Debug.LogError("!!!No inventory manager found pls add");
            return;
        }
        inventoryManager = GetComponent<InventoryManager>();
    }

    void EquipItem()
    {
        if (inventoryManager.inventory[0].canEquip)
        {
            equipable = inventoryManager.inventory[0].equipable;
            equipable.Equip(attachPoint);
        }
    }

    void Interact()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(interactable != null)
            {
                interactable.Use();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Use"))
        {
            if(interactable != null)
            {
                interactable.GetComponent<Interactable>().Use();
            }
        }
    }

    private void FixedUpdate()
    {

    }

    public void DisableControls()
    {
        GetComponent<Movement>().enabled = false;
    }

    public void EnableControls()
    {
        GetComponent<Movement>().enabled    = true;
    }
}
