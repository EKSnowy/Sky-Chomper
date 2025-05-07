using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Player_Script player;
    public GameObject Pot;
    public GameObject Pot2;
    public GameObject Pot3;

    public void Update()
    {

        if (player.getHealth() == 3)
        {
            Pot.SetActive(true);
            Pot2.SetActive(true);
            Pot3.SetActive(true);
        }
        if (player.getHealth() == 2)
        {
            Pot.SetActive(false);
            Pot2.SetActive(true);
            Pot3.SetActive(true);
        }
        if (player.getHealth() == 1)
        {
            Pot.SetActive(false);
            Pot2.SetActive(false);
            Pot3.SetActive(true);
        }
        if (player.getHealth() == 0)
        {
            Pot.SetActive(false);
            Pot2.SetActive(false);
            Pot3.SetActive(false);
        }
    }
}
