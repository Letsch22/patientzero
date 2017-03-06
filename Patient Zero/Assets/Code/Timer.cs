using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerLabel;
    public Text gameOverText;
    public static float startTime;
    public float time;
    private GameObject heart1;
	private bool hasSpawnedDiseaseVision;
    private bool hasSpawnedHeart1;
    private bool hasSpawnedHeart2;
    private bool hasSpawnedFreeze;
	private Image timerBar;
    private PlayerStats playerStats;
    public GameObject heartPrefab;
    public GameObject diseaseVisionPrefab;
    public GameObject freezePrefab;

    internal void Awake()
    {
        time = startTime;
        timerBar = GameObject.FindGameObjectWithTag ("TimerBar").GetComponent<Image>();
		timerBar.fillAmount = 0;
        playerStats = FindObjectOfType<PlayerStats>();
        GameObject heart1 = heartPrefab;
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
            timerLabel.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
        }

		// spawning disease vision item
		if (time <= startTime/2f && hasSpawnedDiseaseVision == false)
		{
		    Instantiate(diseaseVisionPrefab);
			hasSpawnedDiseaseVision = true;
		}
        
        // spawning heart item
        if (time <= (3*startTime)/4f && hasSpawnedHeart1 == false && playerStats.health < 100)
        {
            heart1 = Instantiate(heartPrefab);
            hasSpawnedHeart1 = true;
        }
        // spawning heart item
        if (time <= startTime/4f && hasSpawnedHeart2 == false && playerStats.health < 100 && heart1.GetComponent<SpriteRenderer>().enabled == false)
        {
            Instantiate(heartPrefab);
            hasSpawnedHeart2 = true;
        }
        // spawning freeze item
        if (time <= startTime/4f && hasSpawnedFreeze == false)
        {
            Instantiate(freezePrefab);
            hasSpawnedFreeze = true;
        }

    }

    public void GameOver(bool iWon)
    {
        if (iWon)
        {
            ScoreManager.percentInfected = 1 - (time/startTime);
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }
}
