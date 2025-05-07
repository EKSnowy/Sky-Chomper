using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    public Player_Script player;

    public void Update()
    {

        if (player.isFalling == false)
        {
            //prevents camera from moving side to side
            transform.position = new Vector3(0, player.Yvalue().y + 3f, -10);
        }

    }

}
