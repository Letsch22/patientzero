using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public static float XMin;
    public static float XMax;
    public static float YMin;
    public static float YMax;
    public static float roamYMax;

    internal void Start()
    {
        XMin = -87f;
        YMin = -58f;
        YMax = 39f;
        XMax = 86f;
        roamYMax = 9f;
    }

    public static Vector2 FindFreeLocation(float radius, bool roam)
    {
        float currYMax = YMax;
        if (roam) currYMax = roamYMax;
        Vector2 origin = new Vector2(Random.Range(XMin, XMax), Random.Range(YMin, currYMax));
        while (Physics2D.CircleCast(origin, radius, new Vector2()).collider != null)
        {
            origin = new Vector2(Random.Range(XMin, XMax), Random.Range(YMin, currYMax));
        }
        return origin;
    }
}
