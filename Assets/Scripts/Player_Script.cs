using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [Header("Numbers")]
    //amount of force applied to player when touches a pellet
    public float upwardForce;
    //How fast player moves left and right
    public float moveSpeed;
    //For left and right input
    public float horizontal;
    //Becomes true at the start of the game
    public bool isStart;

    [Header("Rigidbody")]
    public Rigidbody2D RB;
    void Start()
    {
        isStart = true;
        RB.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ///////////Start/////////////

        //Game is paused at the start
        if (isStart)
        {
            //If start of the game, unpauses game and applies gravity once [Spacebar] is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(Vector2.up * upwardForce,ForceMode2D.Impulse);
                RB.gravityScale = .5f;
                isStart = false;
            }
        }
        //Once game is unpaused, everything else runs
        else if (!isStart)
        {
            ///////////Movement/////////////
        
            //Gets the input of whether you're moving right or left (EX: Left arrow and right arrow)
            //horizontal equals -1 if moving left, and equals 1 if moving right. It becomes 0 if no inputs
            horizontal = Input.GetAxisRaw("Horizontal");
            
        }
        
    }
    
    //Called every 30 frames for consistent movement
    public void FixedUpdate()
    {
        RB.velocity = new Vector2(horizontal * moveSpeed,RB.velocity.y);
    }

    //Detects collision if something hits the player's head
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Retrieves the scripts of whatever collides with the player
        Pellet_Script pellet = other.GetComponent<Pellet_Script>();

        //If the script equals pellet
        if (pellet != null)
        {
            //Destroys pellet on contact and applies upwards force
            RB.velocity = Vector2.zero;
            RB.AddForce(Vector2.up * upwardForce,ForceMode2D.Impulse);
            
            pellet.Destroy();
        }
    }
}
