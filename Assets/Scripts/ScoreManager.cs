using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int score = 0;

    public void AddScore(int point)
    {
        score += point;
        text.text = score.ToString();
    }
}
