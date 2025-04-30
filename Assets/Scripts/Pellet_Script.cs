using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Pellet_Script : MonoBehaviour
{
    public GameObject pellet;
    public Player_Script player;

    public void Start()
    {
        //what the fuck
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
    }
    public void pelletdestroy()
    {
        // spawns a new pellet once the one you last collected is destroyed
        Instantiate(pellet, new Vector3(Random.Range(-7, 4), player.Yvalue().y + Random.Range(12, 16), -2), Quaternion.identity);
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
     {
        DIE death = other.GetComponent<DIE>();
        if (death != null)
        {
            pelletdestroy();
        }
     }
    }