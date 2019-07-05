using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorCharacter : MonoBehaviour
{
    public GameObject interactable;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        Raycast();
    }

    void Raycast()
    {
        Vector3 rayDirection  = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Ray ray = new Ray(rayDirection, Camera.main.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 2.0f))
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
