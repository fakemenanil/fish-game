using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public float scoreIncrease;
    [HideInInspector] public float runScore;
    public PlayerMovement player;
    public TMP_Text runScoreText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.dead)
        {
            runScore += scoreIncrease;
            runScoreText.text = runScore.ToString("F1");
        }

        if(player.dead)
        {
            scoreText.text = runScore.ToString("F1");
            if(runScore>PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", runScore);
                player.recordIndicator.SetActive(true);   
            }
            highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("F1");
        }
    }
}
