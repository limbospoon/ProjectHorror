using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineCamTrigger : MonoBehaviour
{
    public GameObject cam;
    public float duration = 3.0f;

    private GameObject playerRef;

    private void Start()
    {
        cam.GetComponent<CinematicCam>().Setup(this, duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: change to check if its the player
        other.gameObject.SetActive(false);
        playerRef = other.gameObject;
        cam.GetComponent<Camera>().enabled = true;
    }

    public void TurnOffCam()
    {
        playerRef.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
