﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public Text healthLabel;
    public int health;
    private Timer timer;
    public Text vaccinesLabel;
    public int numVaccines;

	// Use this for initialization
	void Start ()
	{
		Camera camera = FindObjectOfType<CameraControl>().GetComponent<Camera> ();
//		transform.GetComponent<RectTransform>().anchoredPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
//        vaccinesLabel.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(11.5f, 11.5f, 1));
        healthLabel.text = "Health: " + health;
        vaccinesLabel.text = "Vaccines Left: " + numVaccines;
        timer = FindObjectOfType<Timer>().GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void reduceHealth(int amount)
    {
        health -= amount;
        healthLabel.text = "Health: " + health;
        if (health <= 0)
        {
            timer.GameOver(false);
        }
    }

    public void useVaccine()
    {
        numVaccines -= 1;
        vaccinesLabel.text = "Vaccines Left: " + numVaccines;
        if (numVaccines <= 0)
        {
            timer.GameOver(false);
        }
    }
}
