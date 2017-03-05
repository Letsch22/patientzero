using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public static float XMin;
    public static float XMax;
    public static float YMin;
    public static float YMax;
    public static float roamYMax;
    public static float roamYMin;

    internal void Start()
    {
        XMin = -87f;
        YMin = -58f;
        YMax = 39f;
        XMax = 86f;
        roamYMax = 9f;
        roamYMin = -45f;
    }

    public static Vector2 FindFreeLocation(float radius, bool roam)
    {
        float currYMax = YMax;
        float currYMin = YMin;
        if (roam)
        {
            currYMax = roamYMax;
            currYMin = roamYMin;
        }
        Vector2 origin = new Vector2(Random.Range(XMin, XMax), Random.Range(currYMin, currYMax));
        while (Physics2D.CircleCast(origin, radius, new Vector2()).collider != null)
        {
            origin = new Vector2(Random.Range(XMin, XMax), Random.Range(currYMin, currYMax));
        }
        return origin;
    }
}
