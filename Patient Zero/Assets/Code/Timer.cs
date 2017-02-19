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
    public float time;
	private bool hasSpawnedDiseaseVision;
	private Image timerBar;

    internal void Awake()
    {
//		transform.position = Camera.main.ViewportToWorldPoint(new Vector3(2, 11.5f, 1));
        time = 240f;
		timerBar = GameObject.FindGameObjectWithTag ("TimerBar").GetComponent<Image>();
		timerBar.fillAmount = 0;
    }

    internal void Update()
    {
        
        time -= Time.deltaTime;

		timerBar.fillAmount = 1 - (time / 240f);

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
		if (time <= 120f && hasSpawnedDiseaseVision == false) {
			DiseaseVisionItem diseaseVision = FindObjectOfType<DiseaseVisionItem> ();
			diseaseVision.EnablePickup (true);
			hasSpawnedDiseaseVision = true;
		}

    }

    public void GameOver(bool iWon)
    {
        if (iWon)
        {
            gameOverText.text = "You vaccinated Patient Zero!\nYou Won!\nThe game will restart soon.";
            StartCoroutine(WaitAndRestart(5));
        }
        else
        {
            gameOverText.text = "Game Over!\nThe game will restart soon.";
            StartCoroutine(WaitAndRestart(5));
        }
    }

    IEnumerator WaitAndRestart(float secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
