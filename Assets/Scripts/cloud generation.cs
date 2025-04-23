using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudgeneration : MonoBehaviour
{
    Material fluff;
    float distance;
    public Player_Script player;

    [Range(0f, 0.5f)]
    public float speed;

    void Start()
    {
      fluff = GetComponent<Renderer>().material;
    }

    public void Update()
    {
        speed = player.RB.velocity.y / 10;

        if (player.RB.velocity.y != 0)
        {
            distance += Time.deltaTime * speed;
            fluff.SetTextureOffset("_MainTex", Vector2.up * distance);
        }
    }
}
