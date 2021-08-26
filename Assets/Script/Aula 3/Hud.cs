using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public Text recordScoreText;
    public Text gameOverText;

    private void Start()
    {
        score = 0;
        Birb.birbDeathEvent += GameOver;
        UpdateRecordScore();
    }

    void GameOver()
    {
        Birb.birbDeathEvent -= GameOver;

        gameOverText.text = "MUREU :'(";

        UpdateRecordScore();

        if (PlayerPrefs.HasKey("record"))
        {
            if (score > PlayerPrefs.GetInt("record")) 
                PlayerPrefs.SetInt("record", score);
        }
        else
            PlayerPrefs.SetInt("record", score);

    }

    void UpdateRecordScore()
    {
        if (PlayerPrefs.HasKey("record"))
        {
            recordScoreText.text = PlayerPrefs.GetInt("record").ToString();
        }
        else 
            recordScoreText.text = "-";

    }

    public void ClearRecord()
    {
        PlayerPrefs.DeleteKey("record");
        UpdateRecordScore();
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
