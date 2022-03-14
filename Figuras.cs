using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figuras : MonoBehaviour
{
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = offset;
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.mass = 5;
        //---------------------------Febrero 18
        MeshRenderer mr = cube.GetComponent<MeshRenderer>();
        Color c = new Color(1,1,0);
        mr.material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
