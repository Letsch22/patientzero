using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseVisionItem : ItemControl {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void UseItem() 
	{
		DiseaseControl diseaseControl = FindObjectOfType<DiseaseControl> ();
		diseaseControl.hasDiseaseVision = true;
		diseaseControl.ColorInfectedCivilians (Color.red);
	}
}
