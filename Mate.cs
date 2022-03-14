using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 a;
    Vector3 b;

    void Start()
    {
        a = new Vector3(-1, 2, 3);
        b = new Vector3(-3, 2, -1);

        float rad = Mathf.Acos(Vector3.Dot(a.normalized, b.normalized));
        float deg = Mathf.Rad2Deg * rad;
        Debug.Log("Degrees: " + deg);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 1, 0), Color.green);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 0, 1), Color.blue);

        Debug.DrawLine(Vector3.zero, a, Color.magenta);
        Debug.DrawLine(Vector3.zero, b, Color.yellow);
    }
}
