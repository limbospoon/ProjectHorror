using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [Range(0.0f,1.0f)]
    public float openCloseSpeed = 1.0f;
    public float closeDelay = 1.0f;

    public AudioClip[] audioClips = new AudioClip[2];

    private Animator animator;
    private AudioSource audioSource;
    private bool bClosed = true;
    private float MAXCLOSEDELAY;

    // Start is called before the first frame update
    void Start()
    {
        if(!GetComponent<Animator>())
        {
            Debug.LogError("No animator found pls add one");
            return;
        }
        if(!GetComponent<AudioSource>())
        {
            Debug.LogError("No audio source found pls add");
            return;
        }

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        SetPlayBackSpeed();
        MAXCLOSEDELAY = closeDelay;
    }

    private void Update()
    {
        if(!bClosed)
        {
            AutoClose();
        }
    }

    public override void Use()
    {
        Open();
        closeDelay = MAXCLOSEDELAY;
    }

    void SetPlayBackSpeed()
    {
        animator.speed *= openCloseSpeed;
    }

    void Open()
    {
        if(animator.GetBool("Open"))
        {
            audioSource.clip = audioClips[1];
            SoundManager.PlaySound(audioSource);
            animator.SetBool("Open", false);
            bClosed = true;
        }
        else
        {
            audioSource.clip = audioClips[0];
            SoundManager.PlaySound(audioSource);
            animator.SetBool("Open", true);
            bClosed = false;
        }
    }

    void AutoClose()
    {
        closeDelay -= 1.0f * Time.deltaTime;

        if(closeDelay <= 0.0f)
        {
            Open();
            closeDelay = MAXCLOSEDELAY;
        }
    }
}
