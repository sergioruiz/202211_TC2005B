using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;  // Assets/Resources/AssetBundleInfo.json
    // Start is called before the first frame update
    void Start()
    {
        Users usuarios = JsonUtility.FromJson<Users>(jsonFile.text);
        foreach(User u in usuarios.users)
        {
            Debug.Log(u.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
