using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    //bool to check if the player is falling to death. false by default
    public bool isFalling;
    // hp
    public int health;
    public GameObject gameoverscreen;

    [Header("Rigidbody")]
    public Rigidbody2D RB;

    public Animator AM;
    public float chompTimer;
    public float hurtTimer;
    public Score score;

    public GameObject turnRight;
    public GameObject turnLeft;
    public GameObject turnDown;
    public Quaternion startingRot;
    public soundeffects chomp;
    public soundeffects ouch;
    public void Start()
    {
        Time.timeScale = 1;
        
        isFalling = false;
        isStart = true;
        RB.gravityScale = 0;
        health = 3;
        
        gameoverscreen.SetActive(false);

        hurtTimer = -1;
        chompTimer = -1;
        startingRot = transform.rotation;
    }

    // Update is called once per frame
    public void Update()
    {
        ///////////Start/////////////

        //Game is paused at the start
        if (isStart)
        {
            //If start of the game, unpauses game and applies gravity once [Spacebar] is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
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

        //death falling bool
        if (RB.velocity.y <= -10)
        {
            isFalling = true;
        }
        
        //Controls how long an animation lasts for
        //When the animation is over, it returns to the idle animation
        if (chompTimer > 0)
        {
            chompTimer -= Time.deltaTime;
        }
        
        if (hurtTimer > 0)
        {
            hurtTimer -= Time.deltaTime;
        }
        else if (chompTimer < 0 && hurtTimer < 0)
        {
            AM.Play("Idle Animation");
        }
        
        ///////////////ROTATION//////////////////
        
        //If falling down, makes player look down (WIP)
        /*if (RB.velocity.y < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, turnDown.transform.rotation, Time.deltaTime * 2);
        }
        //Else makes player look up
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startingRot, Time.deltaTime * 2);
        }*/
        
        //Checks the direction the player is going for rotation
        //Rotates right when moving right, and rotates left when moving left
        if (horizontal == 1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, turnRight.transform.rotation, Time.deltaTime * 2);
        }
        else if (horizontal == -1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, turnLeft.transform.rotation, Time.deltaTime * 2);
        }
        //If not moving, player looks up
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startingRot, Time.deltaTime * 2);
        }
        
    }

    //Called every 30 frames for consistent movement
    public void FixedUpdate()
    {
        RB.velocity = new Vector2(horizontal * moveSpeed, RB.velocity.y);
    }

    //Detects collision if something hits the player's head
    public void OnTriggerEnter2D(Collider2D other)
    {
        healpellet medicine = other.GetComponent<healpellet>();
        //Retrieves the scripts of whatever collides with the player
        Pellet_Script pellet = other.GetComponent<Pellet_Script>();
        //hazard script (wip)
        hazard storm_cloud = other.GetComponent<hazard>();

        //If the script equals pellet
        if (pellet != null)
        {
            //Destroys pellet on contact and applies upwards force
            RB.velocity = Vector2.zero;
            RB.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);

            pellet.pelletdestroy();
            chompTimer = .3f;
            AM.Play("Chomp Animation");
            chomp.PlayChomp();
            
        }

        if (medicine != null)
        {
            RB.velocity = Vector2.zero;
            RB.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        }
        //kidna similar code i think
        if (storm_cloud != null)
        {
            storm_cloud.kill();
            health = health - 1;
            hurtTimer = .5f;
            AM.Play("Electrocuted Animation");
            ouch.PlayHit();


            if (health <= 0)
            {
                isFalling = true;
                RB.velocity = Vector2.zero;
                RB.velocity = new Vector2(horizontal * moveSpeed, -3);
                gameoverscreen.SetActive(true);
                score.scoreCheck();
            }

        }
    }
    

    public Vector2 Yvalue()
    {
        return transform.position;
    }

    public int getHealth()
    {
        return health;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game Scene");
    }    

    public void sethealthtozero()
        { 
        health = 0;
        if (health <= 0)
        {
            RB.velocity = Vector2.zero;
            gameoverscreen.SetActive(true);
            score.scoreCheck();

        }
    }
    public void heal()
    {
        if (health <3)
        {
            health++;
        }
    }
}

