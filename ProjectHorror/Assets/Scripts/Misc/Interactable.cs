using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Animator ac;

    private void Start()
    {
        ac = GetComponent<Animator>();
    }

    public void Use()
    {
        if(ac.GetBool("Open") == true)
        {
            ac.SetBool("Open", false);
        }
        else
        {
            ac.SetBool("Open", true);
        }
    }
}
