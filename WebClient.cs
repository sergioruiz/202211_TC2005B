 using System.Collections;
 using System.Collections.Generic;
 using UnityEditor;
 using UnityEngine;
 using UnityEngine.Networking;

// ITESM CCM
// TC2005B - Construcción de Software y Toma de Decisiones
// WebClient (Unity) and WebServer (Python)
// Payload: JSON file
// Sergio Ruiz-Loza. 2022

 // Sources:

 // Python server:
 // https://gist.github.com/mdonkers/63e115cc0c79b4f6b8b3a6b797e485c7

 // Unity client:
 // https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Post.html
 // https://hub.packtpub.com/using-rest-api-unity-part-1-what-rest-and-basic-queries/
 // http://jsonplaceholder.typicode.com/posts
 // https://manuelotheo.com/uploading-raw-json-data-through-unitywebrequest/
 // https://forum.unity.com/threads/posting-json-through-unitywebrequest.476254/
 // https://gist.github.com/emoacht/89590d4e4571d40f9e1b


 public class WebClient : MonoBehaviour
 {

     IEnumerator Upload(string json)
     {
         WWWForm form = new WWWForm();
         form.AddField("bundle", "json");

         //using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8787", form))
         using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8787"))
         {
             //var request = new UnityWebRequest(url, "POST");
             byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
             www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
             www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
             www.SetRequestHeader("Content-Type", "application/json");


             yield return www.SendWebRequest();

             if (www.isNetworkError || www.isHttpError)
             {
                 Debug.Log(www.error);
             }
             else
             {
                 Debug.Log("Form upload complete!");
                 Debug.Log(www.downloadHandler.text);
                 string js = www.downloadHandler.text.Replace('\'', '\"');
                 User u = JsonUtility.FromJson<User>(js);
                 Debug.Log(u.ToString());
             }
         }
     }

     public IEnumerator PostMethod(string json)
     {
         string URL = "http://localhost:8080/";
         string jsonData = json;
         string method = "";

         using (UnityWebRequest req = UnityWebRequest.Put(URL + method, jsonData))
         {
             req.method = UnityWebRequest.kHttpVerbPOST;
             req.SetRequestHeader("Content-Type", "application/json");
             req.SetRequestHeader("Accept", "application/json");
             yield return req.SendWebRequest();
             if(!req.isNetworkError && req.responseCode != 404 )
             {
                 Debug.Log("JSON sent to server!");
             }
             else
             {
                 Debug.Log("JSON not sent to server");
             }
         }
     }

     // Start is called before the first frame update
     void Start()
     {
         //TextAsset productList = Resources.Load<TextAsset>("Text/AssetBundleInfo");
         //string json = EditorJsonUtility.ToJson(productList);
         //Debug.Log(productList.ToString());
         string json = "Hello Server!";
         StartCoroutine(Upload(json));
     }

     // Update is called once per frame
     void Update()
     {

     }


 }
