﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


/// <summary>
/// Unity VideoPlayer Script for Unity 5.6 (currently in beta 0b11 as of March 15, 2017)
/// Blog URL: http://justcode.me/unity2d/how-to-play-videos-on-unity-using-new-videoplayer/
/// YouTube Video Link: https://www.youtube.com/watch?v=nGA3jMBDjHk
/// StackOverflow Disscussion: http://stackoverflow.com/questions/41144054/using-new-unity-videoplayer-and-videoclip-api-to-play-video/
/// Code Contiburation: StackOverflow - Programmer
/// </summary>


public class PlayOnTexture : MonoBehaviour
{



    public VideoPlayer videoPlayer;


    public void Play()
    {
        videoPlayer.gameObject.SetActive(true);
        //Play Video
        videoPlayer.Play();
        videoPlayer.isLooping = true;


    }
    public void Close()
    {
        videoPlayer.Stop();
        videoPlayer.gameObject.SetActive(false);

    }
}