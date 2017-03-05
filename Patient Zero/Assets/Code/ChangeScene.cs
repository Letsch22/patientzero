using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public void SetDifficulty(string diff)
    {
        if (diff.Equals("Easy"))
        {
            Timer.startTime = 240f;
        }
        if (diff.Equals("Medium"))
        {
            Timer.startTime = 180f;
        }
        if (diff.Equals("Hard"))
        {
            Timer.startTime = 120f;
        }
        if (diff.Equals("Deadly"))
        {
            Timer.startTime = 60f;
        }
    }

    public void ChangeToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
