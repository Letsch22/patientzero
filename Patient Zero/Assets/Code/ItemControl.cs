using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemControl : MonoBehaviour {

	public abstract void UseItem ();

	// Use this for initialization
	void Awake ()
	{
	    transform.position = SpawnController.FindFreeLocation(2, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	internal void OnTriggerEnter2D(Collider2D other) 
	{
		PlayerControl playerControl = other.gameObject.GetComponent<PlayerControl> ();
		if (playerControl != null) {
			EnablePickup (false);
			UseItem ();
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void EnablePickup(bool enabled) 
	{
		GetComponent<SpriteRenderer> ().enabled = enabled;
		GetComponent<CircleCollider2D> ().enabled = enabled;
	    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
}
