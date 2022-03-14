using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : MonoBehaviour
{
    public GameObject baqueta;
    public GameObject cilindro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            baqueta.SetActive(true);
            cilindro.SetActive(true);
            baqueta.transform.position = new Vector3(-0.184f, 0.869f, 0);
            baqueta.transform.eulerAngles = new Vector3(0, 0, -69.746f);
        }
    }
}
