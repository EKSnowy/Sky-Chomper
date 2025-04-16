using TMPro;
using UnityEngine;

//using this to control score
public class PlayerScore : MonoBehaviour
{
    public Player_Script kms;
    //public GameObject scoreholder;
    public TextMeshProUGUI score;
    public void Update()
    {
      score.text = "" + Mathf.RoundToInt(kms.Yvalue().y);
    }
}
