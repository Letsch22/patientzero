using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseControl : MonoBehaviour
{
    private float startTimer;
    private float beginTime;
    private CivilianControl[] civilians;
    private int patientZeroIndex;
    private float spreadRate;
	// Use this for initialization
	void Start ()
	{
        civilians = FindObjectsOfType<CivilianControl>();
	    Timer timerClass = FindObjectOfType<Timer>();
        startTimer = FindObjectOfType<Timer>().gameObject.GetComponent<Timer>().time;
	    spreadRate = startTimer/(float)civilians.Length;
	    patientZeroIndex = Random.Range(0, civilians.Length);
        civilians[patientZeroIndex].hasDisease = true;
	    civilians[patientZeroIndex].GetComponent<SpriteRenderer>().color = Color.green;
	    beginTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time - beginTime > spreadRate)
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
            closestToPatientZero.GetComponent<SpriteRenderer>().color = Color.red;
            beginTime = Time.time;
        }
	}
}
