using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseControl : MonoBehaviour
{
    private float currentTime;
    private GameObject[] civilians;
	// Use this for initialization
	void Start ()
	{
	    currentTime = FindObjectsOfType()<Timer>().GetComponent<Timer>();
	    civilians = FindObjectsOfType<CivilianControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
