using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorCharacter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red);
    }
}
