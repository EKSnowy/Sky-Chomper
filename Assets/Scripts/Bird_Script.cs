using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Script : MonoBehaviour
{
    //Yeah i just copied this from my fishing game lol
    public float moveSpeed;
    public int random;
    public bool starting;

    public SpriteRenderer SR;
    public Rigidbody2D RB;
    
    public GameObject bird;
    public Player_Script player;
    void Start()
    {
        starting = true;
        random = Random.Range(1, 3);
        
        //my name is Miles Morales
        //This looks at every object on the scene and see's which one is the player so we can access the script
        //We have to do it this way because of how prefabs are
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
    }

    //Fish starts moving left or right depending on random
    void FixedUpdate()
    {
        Vector2 vel = RB.velocity;
        
        //moves left if number bigger than 1, otherwise right
        if (random > 1 && starting)
        {
            moveSpeed *= -1;
            starting = false;
        }
        
        vel.x = moveSpeed;
        
        RB.velocity = vel;
    }

    //Once fish hits boundary, it turns around
    void Update()
    {
        //If it hits the right side of the screen, it moves left
        if (transform.position.x > 7f)
        {
            transform.position = new Vector3(6.98f, transform.position.y, -2);
            moveSpeed *= -1;
        }
        
        //If it hits the left side of the screen, it moves to the right
        else if (transform.position.x < -7f)
        {
            transform.position = new Vector3(-6.98f, transform.position.y, -2);
            moveSpeed *= -1;
        }

        //Flips sprite when moving left
        if (moveSpeed > -1)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //If it hits the pear wiggler trigger, it resets position like the cloud hazard
        DIE death = other.GetComponent<DIE>();
        if (death != null)
        {
            Reset();
        }

        //If it runs into player, it resets position as well, like if the player hit the cloud hazard
        Player_Script player = other.GetComponent<Player_Script>();
        if (player != null)
        {
            Reset();
        }
    }

    //makes a new bird ahead of the player at a random position and destroys the old bird
    public void Reset()
    {
        Instantiate(bird, new Vector3(Random.Range(-7, 4), player.Yvalue().y + Random.Range(20, 100), -2), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
