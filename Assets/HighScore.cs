using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    private TextMeshProUGUI highScore;
    public static int number;

    private void Start()
    {
        highScore = GetComponent<TextMeshProUGUI>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {       
        
        
    }

    public void GetHighScore()
    {
        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
            Debug.Log("ugabuga");
        }

    }
}
