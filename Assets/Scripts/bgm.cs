using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class bgm : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip[] musicList;

    void Start()
    {
        randomizeSong();
    }

    public void Update()
    {
        //If the current music is over, play a random song
        if (!BGM.isPlaying)
        {
            randomizeSong();
        }
    }

    public void randomizeSong()
    {
        int random = Random.Range(0, musicList.Length);

        BGM.clip = musicList[random];
        BGM.Play();
    }
}
