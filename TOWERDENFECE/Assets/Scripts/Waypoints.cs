using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        // Get all children of the waypoints
        points = new Transform[transform.childCount];
        // Loop through all children
        for (int i = 0; i < points.Length; i++)
        {
            // Get the child
            points[i] = transform.GetChild(i);
        }
    }
}