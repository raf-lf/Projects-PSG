using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public Text gameOverText;

    private void Start()
    {
        score = 0;
        Birb.birbDeathEvent += GameOver;
    }

    void GameOver()
    {
        gameOverText.text = "MUREU :'(";
        Birb.birbDeathEvent -= GameOver;

    }


    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
