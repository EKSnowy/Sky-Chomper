using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hazard : MonoBehaviour
{
    public Player_Script player;
    public GameObject storm_cloud;
    //making sure the storm clouds cant spawn unfairly
    public GameObject pellet;

    public void Start()
    {
        //alright lets do this one last time
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
    }
    public void kill()
    {
        // spawns a new storm cloud once the one you last collected is destroyed (NOT OFFSCREEN. IM WORKING ON THAT)
        Instantiate(storm_cloud, new Vector3(Random.Range(-7, 4), player.Yvalue().y + Random.Range(30, 50), -2), Quaternion.identity);
        Destroy(this.gameObject);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DIE death = other.GetComponent<DIE>();
        if (death != null)
        {
            kill();
        }

        Pellet_Script pellet = other.GetComponent<Pellet_Script>();
        if (pellet != null)
        {
            transform.position = new Vector3(Random.Range(-7, 4), transform.position.y, -2);
        }
    }
}
