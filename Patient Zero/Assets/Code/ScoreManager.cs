using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static float percentInfected;
    public int percentInfection;

	// Use this for initialization
	void Start ()
	{
	    percentInfection = (int)(percentInfected*100);
	    GetComponent<Text>().text = "Total infection spread: " + percentInfection + "%";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
