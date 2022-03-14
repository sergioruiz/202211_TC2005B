using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperaUsuario : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Persistente = GameObject.Find("Persistente");
        Persiste p = Persistente.GetComponent<Persiste>();
        Debug.Log(p.u.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




