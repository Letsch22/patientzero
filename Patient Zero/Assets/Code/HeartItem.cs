using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : ItemControl {

	// Use this for initialization
    public override void UseItem()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats.health.Equals(90))
        {
            playerStats.reduceHealth(-10);
        }
        else
        {
            playerStats.reduceHealth(-20);
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
