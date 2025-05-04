using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip[] musicList;

    void Start()
    {
        randomizeSong();
    }
    public void randomizeSong()
    {
        int random = Random.Range(0, musicList.Length);

        BGM.clip = musicList[random];
        BGM.Play();
    }
}
