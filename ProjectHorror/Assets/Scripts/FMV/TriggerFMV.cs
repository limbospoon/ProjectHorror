using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TriggerFMV : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject vidCam;

    private GameObject playerRef;

    private void Start()
    {
        if(!GetComponent<VideoPlayer>())
        {
            Debug.LogError("No video player found!!!");
            return;
        }

        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += OnMovieFinished;
        videoPlayer.prepareCompleted += OnMoviePrepared;

        vidCam.SetActive(false);
    }

    void OnMovieFinished(VideoPlayer vp)
    {
        playerRef.SetActive(true);
        vidCam.SetActive(false);
        this.gameObject.SetActive(false);
    }

    void OnMoviePrepared(VideoPlayer vp)
    {
        videoPlayer.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: Make sure its the player
        playerRef = other.gameObject;
        other.gameObject.SetActive(false);
        vidCam.SetActive(true);
        videoPlayer.Prepare();
    }
}
