using TMPro;
using UnityEngine;

//using this to control score
public class Score : MonoBehaviour
{
    public Player_Script kms;
    //public GameObject scoreholder;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    public Player_Script player;
    public float scoreNum;
    public static float highscoreNum;

    public void Update()
    {
        if (player.RB.velocity.y > 0)
        {
            //score based on y value. round to the nearest whole
            score.text = "" + Mathf.RoundToInt(kms.Yvalue().y);
            scoreNum = kms.Yvalue().y;
            scoreNum = Mathf.RoundToInt(scoreNum);
        }
    }

    public void scoreCheck()
    {
        if (scoreNum > highscoreNum) // if the high score is lower than the score
        {
            highscoreNum = scoreNum; //update the internal score to highscore
            highscore.text = "Highscore: " + highscoreNum;//updates high score text
        }

        else
        {
            highscore.text = "Highscore: " + highscoreNum; //then update text and keep highscore the same
        }
    }
}