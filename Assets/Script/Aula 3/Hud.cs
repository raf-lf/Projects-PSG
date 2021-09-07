using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hud : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public Text recordScoreText;
    public Text deathsText;
    public Text gameOverText;

    public SavedData savedDataObject;

    private void Start()
    {
        score = 0;
        Birb.birbDeathEvent += GameOver;

        if (PlayerPrefs.HasKey("savedData"))
        {
            savedDataObject = JsonUtility.FromJson<SavedData>(PlayerPrefs.GetString("savedData"));
            
        }
        else 
        {
            savedDataObject = new SavedData();
            savedDataObject.deaths = 0;

        }

        UpdateInfos();

    }

    void GameOver()
    {
        Birb.birbDeathEvent -= GameOver;

        savedDataObject.deaths++;

        gameOverText.text = "MUREU :'(";


        if (PlayerPrefs.HasKey("record"))
        {
            if (score > PlayerPrefs.GetInt("record")) 
                PlayerPrefs.SetInt("record", score);
        }
        else
            PlayerPrefs.SetInt("record", score);

        PlayerPrefs.SetString("savedData", JsonUtility.ToJson(savedDataObject));

        UpdateInfos();
        
        Invoke(nameof(Restart), 3);

    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

    }

    void UpdateInfos()
    {

        deathsText.text = savedDataObject.deaths.ToString();

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
        PlayerPrefs.DeleteAll();
        UpdateInfos();

    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

}
