using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineCamTrigger : MonoBehaviour
{
    public GameObject cam;
    public GameObject objectToAnimate;
    public float duration = 3.0f;
    public int spriteIndex;
    public string animName;
    public bool animate = false;

    private GameObject playerRef;

    private void Start()
    {
        cam.GetComponent<CinematicCam>().Setup(this, duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: change to check if its the player
        if(other.gameObject.tag == "Player")
        {
            playerRef = other.gameObject;
            playerRef.GetComponent<HorrorCharacter>().ThirdPersonMode(spriteIndex);
            playerRef.GetComponent<HorrorCharacter>().DisableControls();
            cam.GetComponent<Camera>().enabled = true;

            if (animate)
            {
                AnimateObject();
            }
        }
    }

    private void AnimateObject()
    {
        Animator anim = objectToAnimate.GetComponent<Animator>();
        anim.Play(animName);
    }

    public void TurnOffCam()
    {
        playerRef.SetActive(true);
        playerRef.GetComponent<HorrorCharacter>().FirstPersonMode();
        playerRef.GetComponent<HorrorCharacter>().EnableControls();
        this.gameObject.SetActive(false);
    }
}
