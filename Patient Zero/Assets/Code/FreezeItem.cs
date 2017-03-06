using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeItem : ItemControl {

	// Use this for initialization
    public override void UseItem()
    {
        GameObject[] walkways = GameObject.FindGameObjectsWithTag("Walkway");
        foreach (GameObject walkway in walkways)
        {
            StartCoroutine(FreezeWalkwayAndWait(walkway, 15));
        }
        GameObject[] civilians = GameObject.FindGameObjectsWithTag("Civilian");
        foreach (GameObject civilian in civilians)
        {
            StartCoroutine(FreezeAndWait(civilian, 15));
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FreezeAndWait(GameObject civilian, int secs)
    {
        civilian.GetComponent<CivilianControl>().isFrozen = true;
        yield return new WaitForSeconds(secs);
        civilian.GetComponent<CivilianControl>().isFrozen = false;
    }

    IEnumerator FreezeWalkwayAndWait(GameObject walkway, int secs)
    {
        int initialSpeed = walkway.GetComponent<MovingWalkway>().speed;
        walkway.GetComponent<MovingWalkway>().speed = 0;
        yield return new WaitForSeconds(secs);
        walkway.GetComponent<MovingWalkway>().speed = initialSpeed;
    }
}
