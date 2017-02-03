using System;
using UnityEngine;
using UnityEngine.UI;

// Daniel Letscher

/// <summary>
/// Keeps track of the scores of the players.
/// </summary>
public class Timer : MonoBehaviour
{
    public Text timerLabel;

    private float time;

    internal void Start()
    {
        time = 300f;
		transform.position = Camera.main.ViewportToWorldPoint(new Vector3(2, 12, 1));
    }

    internal void Update()
    {
        if (time < 0)
        {
            print("game ova"); // TODO implement game over function
        }
        time -= Time.deltaTime;

        var minutes = Mathf.Floor(time/60); 
        var seconds = time%60; 
        var fraction = Mathf.Floor((time*100)%100);

        //update the label value
        timerLabel.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
    }
}
