using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Player_Script player;
    public void Update()
    {
        //makes it so camera cant move side to side
        transform.position = new Vector3(0, player.Yvalue().y, -10);
    }
}
