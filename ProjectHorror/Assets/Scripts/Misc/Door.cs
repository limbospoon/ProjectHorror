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
    private Rigidbody rb;
    private float currentPlaybackSpeed;

    public enum DoorState
    {
        Open,
        Closed,
        Opening,
        Closing
    }
    public DoorState doorState;

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

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.speed = openCloseSpeed;  
    }

    private void Update()
    {
        switch(doorState)
        {
            case DoorState.Opening:
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Opened"))
                    {
                        doorState = DoorState.Open;
                        rb.isKinematic = true;
                    }
                    break;
                }
            case DoorState.Closing:
                {
                    if(animator.GetCurrentAnimatorStateInfo(0).IsName("Closed"))
                    {
                        doorState = DoorState.Closed;
                        rb.isKinematic = true;
                    }
                    break;
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            rb.isKinematic = true;
            Debug.Log("Hit player");
            currentPlaybackSpeed = animator.speed;
            animator.speed = 0;
        }
    }

    public override void Use()
    {
        switch(doorState)
        {
            case DoorState.Open:
                {
                    audioSource.clip = audioClips[1];
                    SoundManager.PlaySound(audioSource);
                    animator.SetBool("Open", false);
                    doorState = DoorState.Closing;
                    rb.isKinematic = false;
                    break;
                }
            case DoorState.Closed:
                {
                    audioSource.clip = audioClips[0];
                    SoundManager.PlaySound(audioSource);
                    animator.SetBool("Open", true);
                    doorState = DoorState.Opening;
                    rb.isKinematic = false;
                    break;
                }
            case DoorState.Opening:
                {
                    animator.speed = currentPlaybackSpeed;
                    rb.isKinematic = false;
                    break;
                }
            case DoorState.Closing:
                {
                    animator.speed = currentPlaybackSpeed;
                    rb.isKinematic = false;
                    break;
                }
        }
    }
}
