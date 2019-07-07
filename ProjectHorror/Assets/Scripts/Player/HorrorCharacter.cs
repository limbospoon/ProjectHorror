using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorCharacter : MonoBehaviour
{
    public GameObject interactable;
    public float interactRange = 10.0f;

    private InventoryManager inventoryManager;

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

    public void PickupItem(InventoryItem item)
    {
        inventoryManager.Add(item);
    }

    private void FixedUpdate()
    {
        Raycast();
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
}
