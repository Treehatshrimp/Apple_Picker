using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; //Use this if new version

public class HighScore : MonoBehaviour
{
    static private TMP_Text _UI_TEXT;
    static private int _SCORE = 1000;

    private TMP_Text txtCom; //txtCom is a reference o this GO's Text component

    private void Awake()
    {
        _UI_TEXT = GetComponent<TMP_Text>();
        //If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        //Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }
    static public int SCORE
    {
        get { return _SCORE; }
        private set 
        { 
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }
    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE)
        {
            return; //If scoreToTry is too low, return
        }
        SCORE = scoreToTry;
    }
    //The following code allows you to easily reset the PlayerPrefs HighScore
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000");
        }
    }
}
