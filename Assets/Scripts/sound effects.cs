using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffects : MonoBehaviour
{

    public AudioSource SFX;
    public AudioClip Chomp;
    public AudioClip Hitsound;
    public AudioClip Healsound;

    public void PlayChomp()
    {
        SFX.PlayOneShot(Chomp);
    }
    public void PlayHit()
    {
        SFX.PlayOneShot(Hitsound);
    }
    
    public void PlayHeal()
    {
        SFX.PlayOneShot(Healsound);
    }
}
