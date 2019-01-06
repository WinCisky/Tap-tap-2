using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //reference
    public static ScoreManager SM = null;
    //score
    private int score = 0;
    //max score
    public int max_score = 0;
    //text of the score
    public TextMeshProUGUI text_score;

    // Start is called before the first frame update
    void Start()
    {
        if (SM == null)
            SM = this;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ad a point to the score
    public void AddPoint()
    {
        score++;
        if (score > max_score)
            max_score = score;
        text_score.text = score.ToString();
    }

    //remove a point from the score
    public void RemovePoint()
    {
        score--;
        text_score.text = score.ToString();
    }

    //remove multiple points from the score
    public void RemovePoint(int amount)
    {
        score-= amount;
        text_score.text = score.ToString();
        if(score < 0)
        {
            GameManager.GM.GameOver();
        }
    }
}
