using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for(int i = 0;i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
