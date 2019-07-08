using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCam : MonoBehaviour
{
    public Camera cam;
    public float duration = 3.0f;

    private GameObject playerRef;

    private void OnTriggerEnter(Collider other)
    {
        //TODO: change to check if its the player
        other.gameObject.SetActive(false);
        playerRef = other.gameObject;
        cam.enabled = true;
    }

    private void CineCam()
    {
        while (duration > 0.0f)
        {
            duration -= 1.0f * Time.deltaTime;
        }
        playerRef.SetActive(true);
        cam.enabled = false;
        this.gameObject.SetActive(false);
    }
}
