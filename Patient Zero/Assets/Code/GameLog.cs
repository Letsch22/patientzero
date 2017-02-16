using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLog : MonoBehaviour
{

    public Text logText;

	// Use this for initialization
	void Start () {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(2.5f, 1.5f, 1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
