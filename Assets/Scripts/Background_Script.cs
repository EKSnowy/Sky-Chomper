using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Background_Script : MonoBehaviour
{
    public GameObject Tile;

    public void OnTriggerEnter2D (Collider2D other)
    {
        //Retrieves the scripts of whatever collides with the player
        Player_Script chompy = other.GetComponent<Player_Script>();

        if (chompy != null)
        {
            Debug.Log("AAAHHHH HELP ME");
        }
    }
}
