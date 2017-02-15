using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Text healthLabel;
    public int health;

	// Use this for initialization
	void Start ()
	{
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(13, 12, 1));
        healthLabel.text = "Health: " + health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void reduceHealth(int amount)
    {
        health -= amount;
        healthLabel.text = "Health: " + health;
    }
}
