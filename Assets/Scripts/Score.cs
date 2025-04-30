using TMPro;
using UnityEngine;

//using this to control score
public class PlayerScore : MonoBehaviour
{
    public Player_Script kms;
    //public GameObject scoreholder;
    public TextMeshProUGUI score;
    public Player_Script player;

    public void Update()
    {
        if (player.RB.velocity.y > 0)
        {
            //score based on y value. round to the nearest whole
            score.text = "" + Mathf.RoundToInt(kms.Yvalue().y);
        }
    }
}