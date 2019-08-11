using System.Collections;
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

    private Movement movement;
    private InventoryManager inventoryManager;
    private Equipable equipable;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(!GetComponent<InventoryManager>())
        {
            Debug.LogError("!!!No inventory manager found pls add");
            return;
        }
        inventoryManager = GetComponent<InventoryManager>();
        movement = GetComponent<Movement>();
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem();
        }

        movement.Move(new Vector3(0, 0, Input.GetAxisRaw("Vertical")));
    }

    public void PickupItem(InventoryItem item)
    {
        inventoryManager.Add(item);
    }

    private void FixedUpdate()
    {

    }

    public void DisableControls()
    {
        GetComponent<Movement>().enabled    = false;
        GetComponent<MouseLook>().enabled   = false;
    }

    public void EnableControls()
    {
        GetComponent<Movement>().enabled    = true;
        GetComponent<MouseLook>().enabled   = true;
    }
}
