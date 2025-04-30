using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIE : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Retrieves the scripts of whatever collides with the player
        Player_Script player = other.GetComponent<Player_Script>();
        hazard storm_cloud = other.GetComponent<hazard>();


        if (player != null)
        {
            Time.timeScale = 0;
            player.sethealthtozero();
        }

    }
}
