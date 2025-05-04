using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffects : MonoBehaviour
{

    public AudioSource SFX;
    public AudioClip Chomp;
    public AudioClip Hitsound;

    public void PlayChomp()
    {
        SFX.PlayOneShot(Chomp);
    }
    public void PlayHit()
    {
        SFX.PlayOneShot(Hitsound);
    }
}
