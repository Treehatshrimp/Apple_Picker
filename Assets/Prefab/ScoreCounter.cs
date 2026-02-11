using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //lets use Text : Legacy
using TMPro; //Use this if new version

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TMP_Text uiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0"); //this 0 is zero
    }
}
