using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseControl : MonoBehaviour
{
    private float startTimer;
    private CivilianControl[] civilians;
    private int patientZeroIndex;
    private float spreadRate;
	public bool hasDiseaseVision;
	private List<CivilianControl> infectedCivilians;

	// Use this for initialization
	void Start ()
	{
        startTimer = FindObjectOfType<Timer>().gameObject.GetComponent<Timer>().time;
        civilians = FindObjectsOfType<CivilianControl>();
	    spreadRate = startTimer/((float)civilians.Length - 1f);
	    float distanceToPatientZero = 0;
	    PlayerControl player = FindObjectOfType<PlayerControl>();
	    while (distanceToPatientZero < 35)
	    {
            patientZeroIndex = Random.Range(0, civilians.Length);
	        distanceToPatientZero = Vector3.Distance(civilians[patientZeroIndex].transform.position,
	            player.transform.position);
	    }
	    
        civilians[patientZeroIndex].hasDisease = true;
	    civilians[patientZeroIndex].GetComponent<CivilianControl>().isPatientZero = true;
		infectedCivilians = new List<CivilianControl>();
		infectedCivilians.Add (civilians [patientZeroIndex]);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float currentTimer = FindObjectOfType<Timer>().gameObject.GetComponent<Timer>().time;
        if (startTimer - currentTimer > spreadRate)
        {
            float closestToPatientZeroDistance = float.PositiveInfinity;
            CivilianControl closestToPatientZero = civilians[0];
            foreach (CivilianControl civilian in civilians)
            {
                if (Vector3.Distance(civilian.transform.position, civilians[patientZeroIndex].transform.position) <
                    closestToPatientZeroDistance && civilian.hasDisease == false)
                {
                    closestToPatientZeroDistance = Vector3.Distance(civilian.transform.position,
                        civilians[patientZeroIndex].transform.position);
                    closestToPatientZero = civilian;
                }
            }
            closestToPatientZero.hasDisease = true;
			infectedCivilians.Add (closestToPatientZero);
			if (hasDiseaseVision) {
				closestToPatientZero.GetComponent<SpriteRenderer>().color = Color.red;
                closestToPatientZero.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            startTimer = FindObjectOfType<Timer>().gameObject.GetComponent<Timer>().time;
        }
	}

	public void ColorInfectedCivilians(Color color) {
		foreach (CivilianControl civ in infectedCivilians) {
			civ.GetComponent<SpriteRenderer> ().color = Color.red;
            civ.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
	}
}
