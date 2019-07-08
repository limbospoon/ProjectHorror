using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCam : MonoBehaviour
{
    private CineCamTrigger camTrigger;
    private float duration;

    public void Setup(CineCamTrigger trigger, float dur)
    {
        camTrigger = trigger;
        duration = dur;
    }

    private void Update()
    {
        if(GetComponent<Camera>().enabled)
        {
            duration -= 1.0f * Time.deltaTime;

            if (duration <= 0.0f)
            {
                camTrigger.TurnOffCam();
                this.gameObject.SetActive(false);
            }
        } 
    }
}
