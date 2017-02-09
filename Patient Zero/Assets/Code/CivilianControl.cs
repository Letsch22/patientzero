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
	        behaviorSet = wander(ForwardSpeed, timeStart, timeToWander, Vector3.up, Vector3.down, "movingUp", "movingDown");
	    }
        if (behavior == 1)
        {
            behaviorSet = wander(ForwardSpeed, timeStart, timeToWander, Vector3.left, Vector3.right, "movingLeft", "movingRight");
        }
        if (behavior == 2)
        {
            behaviorSet = wander(ForwardSpeed, timeStart, timeToWander, Vector3.right, Vector3.left, "movingRight", "movingLeft");
        }
        if (behavior == 3)
        {
            behaviorSet = wander(ForwardSpeed, timeStart, timeToWander, Vector3.down, Vector3.up, "movingDown", "movingUp");
        }
    }

    private bool wander(float speed, float timeStart, float timeToWander, Vector3 initialDirection, Vector3 returnDirection, 
        string initialAnimationVariable, string returnAnimationVariable)
    {
        if (Time.time - timeStart < timeToWander)
        {
            transform.position += speed * initialDirection*Time.deltaTime;
            animator.SetBool(initialAnimationVariable, true);
        }
        else if (Time.time - timeStart < timeToWander*2)
        {
            transform.position += speed * returnDirection*Time.deltaTime;
            animator.SetBool(returnAnimationVariable, true);
        }
        else if (Time.time - timeStart >= timeToWander*2)
        {
            return false;
        }
        return true;
    }
}
