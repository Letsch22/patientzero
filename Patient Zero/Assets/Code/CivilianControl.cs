using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianControl : MonoBehaviour
{

    public bool hasDisease;
    public float ForwardSpeed = 5f;
    private bool behaviorSet;
    private int behavior = 0;
    private float timeStart;
    private Animator animator;
    private int timeToWander = 2;
    // Use this for initialization
    void Start ()
	{
	    hasDisease = false;
	    behaviorSet = false;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("movingUp", false);
        animator.SetBool("movingRight", false);
        animator.SetBool("movingLeft", false);
        animator.SetBool("movingDown", false);
        if (!behaviorSet)
	    {
	        behavior = Random.Range(0, 3);
	        behaviorSet = true;
	        timeStart = Time.time;
	        timeToWander = Random.Range(2, 5);
	    }
	    if (behavior == 0)
	    {
	        if (Time.time - timeStart < timeToWander)
	        {
                transform.position += ForwardSpeed * Vector3.up * Time.deltaTime;
                animator.SetBool("movingUp", true);
            }
	        else if (Time.time - timeStart < timeToWander*2)
	        {
                transform.position += ForwardSpeed * Vector3.down * Time.deltaTime;
                animator.SetBool("movingDown", true);
            }
	        else if (Time.time - timeStart >= timeToWander*2)
	        {
	            behaviorSet = false;
	        }
	    }
        if (behavior == 1)
        {
            if (Time.time - timeStart < timeToWander)
            {
                transform.position += ForwardSpeed * Vector3.left * Time.deltaTime;
                animator.SetBool("movingLeft", true);
            }
            else if (Time.time - timeStart < timeToWander*2)
            {
                transform.position += ForwardSpeed * Vector3.right * Time.deltaTime;
                animator.SetBool("movingRight", true);
            }
            else if (Time.time - timeStart >= timeToWander*2)
            {
                behaviorSet = false;
            }
        }
        if (behavior == 2)
        {
            if (Time.time - timeStart < timeToWander)
            {
                transform.position += ForwardSpeed * Vector3.right * Time.deltaTime;
                animator.SetBool("movingRight", true);
            }
            else if (Time.time - timeStart < timeToWander*2)
            {
                transform.position += ForwardSpeed * Vector3.left * Time.deltaTime;
                animator.SetBool("movingLeft", true);
            }
            else if (Time.time - timeStart >= timeToWander*2)
            {
                behaviorSet = false;
            }
        }
        if (behavior == 3)
        {
            if (Time.time - timeStart < timeToWander)
            {
                transform.position += ForwardSpeed * Vector3.down * Time.deltaTime;
                animator.SetBool("movingDown", true);
            }
            else if (Time.time - timeStart < timeToWander*2)
            {
                transform.position += ForwardSpeed * Vector3.up * Time.deltaTime;
                animator.SetBool("movingUp", true);
            }
            else if (Time.time - timeStart >= timeToWander*2)
            {
                behaviorSet = false;
            }
        }
    }
}
