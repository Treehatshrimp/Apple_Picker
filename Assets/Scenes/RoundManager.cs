using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class RoundManager : MonoBehaviour
{
    public TMP_Text roundText; // drag your TextMeshPro UI here
    private int round = 1;

    void Start()
    {
        UpdateRoundText();
    }

    public void NextRound()
    {
        round++;
        UpdateRoundText();
    }

    void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Round: " + round;
        }
    }
}