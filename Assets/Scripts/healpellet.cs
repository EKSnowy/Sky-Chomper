using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class healpellet : MonoBehaviour
{
    public GameObject healPellet;
    public GameObject particle;
    public Player_Script player;
    public void Start()
    {
        //what the fuck
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
    }
    public void pelletdestroy()
    {
        // spawns a new pellet once the one you last collected is destroyed
        Instantiate(healPellet, new Vector3(Random.Range(-7, 4), player.Yvalue().y + Random.Range(100, 200), -2), Quaternion.identity);
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        DIE death = other.GetComponent<DIE>();
        if (death != null)
        {
            pelletdestroy();
        }
        Player_Script heal = other.GetComponent<Player_Script>();
        if (heal != null)
        {
            heal.heal();
            pelletdestroy();
        }
    }


}