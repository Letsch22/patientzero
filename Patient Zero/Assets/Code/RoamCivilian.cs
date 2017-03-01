using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class RoamCivilian : CivilianControl
{


    private bool reachedGoal = true;
    private Vector3 goal;
    private Vector3 direction;

    internal override void engageBehavior()
    {
        if (reachedGoal)
        {
            goal = SpawnController.FindFreeLocation(1, true);
            direction = goal - transform.position;
            direction = direction/direction.magnitude;
            reachedGoal = false;
        }
        Vector3 pointedDirection = findNearestDirection(direction);
        trailFootprints(pointedDirection);
        if (pointedDirection == Vector3.up)
        {
            animator.SetBool("movingUp", true);
        }
        else if (pointedDirection == Vector3.down)
        {
            animator.SetBool("movingDown", true);
        }
        else if (pointedDirection == Vector3.left)
        {
            animator.SetBool("movingLeft", true);
        }
        else if (pointedDirection == Vector3.right)
        {
            animator.SetBool("movingRight", true);
        }
        if (Vector3.Distance(goal, transform.position) > 2)
        {
            transform.position += ForwardSpeed*direction*Time.deltaTime;
        }
        else
        {
            reachedGoal = true;
        }
    }

    private Vector3 findNearestDirection(Vector3 direction)
    {
        List<Vector3> directionList = new List<Vector3>();
        directionList.Add(Vector3.up);
        directionList.Add(Vector3.down);
        directionList.Add(Vector3.left);
        directionList.Add(Vector3.right);
        Vector3 ret = Vector3.zero;
        float max = Mathf.NegativeInfinity;
        foreach (Vector3 dir in directionList)
        {
            float dot = Vector3.Dot(direction, dir);
            if (dot > max)
            {
                ret = dir;
                max = dot;
            }
        }
        return ret;
    }
}
