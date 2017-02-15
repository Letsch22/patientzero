using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseControl : MonoBehaviour
{
    private float startTimer;
    private CivilianControl[] civilians;
    private int patientZeroIndex;
    private float spreadRate;
	// Use this for initialization
	void Start ()
	{
        startTimer = FindObjectOfType<Timer>().gameObject.GetComponent<Timer>().time;
        civilians = FindObjectsOfType<CivilianControl>();
	    spreadRate = startTimer/((float)civilians.Length - 1f);
	    patientZeroIndex = Random.Range(0, civilians.Length);
        civilians[patientZeroIndex].hasDisease = true;
	    civilians[patientZeroIndex].GetComponent<CivilianControl>().isPatientZero = true;
	    //civilians[patientZeroIndex].GetComponent<SpriteRenderer>().color = Color.green;
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
            //closestToPatientZero.GetComponent<SpriteRenderer>().color = Color.red;
            startTimer = FindObjectOfType<Timer>().gameObject.GetComponent<Timer>().time;
        }
	}
}
