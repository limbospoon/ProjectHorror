using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if(!GetComponent<Animator>())
        {
            Debug.LogError("No animator found pls add one");
            return;
        }
        animator = GetComponent<Animator>();
    }

    public override void Use()
    {
        Open();
    }

    void Open()
    {
        if(animator.GetBool("Open"))
        {
            animator.SetBool("Open", false);
        }
        else
        {
            animator.SetBool("Open", true);
        }
    }
}
