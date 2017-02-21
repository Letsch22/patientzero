using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : ItemControl {

	// Use this for initialization
    public override void UseItem()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.reduceHealth(-10);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
