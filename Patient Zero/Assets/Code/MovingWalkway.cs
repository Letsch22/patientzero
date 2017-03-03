using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalkway : MonoBehaviour
{

    public bool movingRight;
    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player") || coll.gameObject.tag.Equals("Civilian"))
        {
            if (movingRight)
            {
                coll.attachedRigidbody.velocity = speed*Vector3.right;
            }
            else
            {
                coll.attachedRigidbody.velocity = speed * Vector3.left;
            }
        }
    }

    internal void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player") || coll.gameObject.tag.Equals("Civilian"))
        {
            coll.attachedRigidbody.velocity = Vector3.zero;
        }
    }
}
