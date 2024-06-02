using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class textscore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (scores.Instance != null)
        {
            scoreText.text = "Total Score: " + scores.Instance.TotalScore.ToString();
        }
    }
}
