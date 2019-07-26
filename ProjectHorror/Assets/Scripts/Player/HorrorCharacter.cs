﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class HorrorCharacter : MonoBehaviour
{
    public GameObject interactable;
    public float interactRange = 10.0f;
    public Transform attachPoint;
    public SpriteAtlas spriteAtlas;


    private InventoryManager inventoryManager;
    private GameObject firstPersonModel;
    private GameObject thirdPersonModel;
    private Equipable equipable;
    private Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

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

        firstPersonModel = transform.GetChild(0).gameObject;
        thirdPersonModel = transform.GetChild(1).gameObject;
        spriteRenderer = thirdPersonModel.GetComponent<SpriteRenderer>();

        sprites = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(sprites);
    }

    void EquipItem()
    {
        if (inventoryManager.inventory[0].canEquip)
        {
            equipable = inventoryManager.inventory[0].equipable;
            equipable.Equip(attachPoint);
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
    }

    public void PickupItem(InventoryItem item)
    {
        inventoryManager.Add(item);
    }

    private void FixedUpdate()
    {
        if(firstPersonModel.activeInHierarchy)
        {
            Raycast();
        }
    }

    void Raycast()
    {
        Vector3 rayDirection  = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Ray ray = new Ray(rayDirection, Camera.main.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactRange))
        {
            if(hit.collider.GetComponent<Interactable>())
            {
                interactable = hit.collider.gameObject;
            }
        }
        else
        {
            interactable = null;
        }

        Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red);
    }

    public void ThirdPersonMode(int spriteIndex)
    {
        spriteRenderer.sprite = sprites[spriteIndex];
        thirdPersonModel.SetActive(true);
        firstPersonModel.SetActive(false);
    }

    public void FirstPersonMode()
    {
        thirdPersonModel.SetActive(false);
        firstPersonModel.SetActive(true);
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
