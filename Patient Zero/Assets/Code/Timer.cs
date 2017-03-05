﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Daniel Letscher

/// <summary>
/// Keeps track of the scores of the players.
/// </summary>
public class Timer : MonoBehaviour
{
    public Text timerLabel;
    public Text gameOverText;
    public static float startTime;
    public float time;
	private bool hasSpawnedDiseaseVision;
    private bool hasSpawnedHeart;
	private Image timerBar;
    private PlayerStats playerStats;

    internal void Awake()
    {
        time = startTime;
        timerBar = GameObject.FindGameObjectWithTag ("TimerBar").GetComponent<Image>();
		timerBar.fillAmount = 0;
        playerStats = FindObjectOfType<PlayerStats>();
    }

    internal void Update()
    {
        
        time -= Time.deltaTime;

		timerBar.fillAmount = 1 - (time / startTime);

        var minutes = Mathf.Floor(time/60); 
        var seconds = time%60; 
        var fraction = Mathf.Floor((time*100)%100);
        if (time <= 0)
        {
            GameOver(false);
            timerLabel.text = string.Format("{0:00} : {1:00} : {2:00}", 0, 0, 0);
        }
        else
        {
            //update the label value
            timerLabel.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
        }

		// spawning disease vision item
		if (time <= startTime/2f && hasSpawnedDiseaseVision == false) {
			DiseaseVisionItem diseaseVision = FindObjectOfType<DiseaseVisionItem> ();
			diseaseVision.EnablePickup (true);
			hasSpawnedDiseaseVision = true;
		}
        // spawning heart item
        if (time <= (3*startTime)/4f && hasSpawnedHeart == false && playerStats.health < 100)
        {
            HeartItem heartItem = FindObjectOfType<HeartItem>();
            heartItem.EnablePickup(true);
            hasSpawnedHeart = true;
        }

    }

    public void GameOver(bool iWon)
    {
        if (iWon)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }
}
