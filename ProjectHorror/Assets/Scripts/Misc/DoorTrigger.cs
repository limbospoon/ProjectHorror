using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    private HorrorCharacter horrorCharacter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            horrorCharacter = other.GetComponent<HorrorCharacter>();
            horrorCharacter.interactable = door;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            horrorCharacter.interactable = null;
            horrorCharacter = null;
        }
    }
}
