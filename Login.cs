using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField usr;
    public TMP_InputField pwd;
    public Persiste persiste; // Es la instancia de un Script de tipo "Persiste"
    
    IEnumerator Upload(string url)
     {
         WWWForm form = new WWWForm();
         form.AddField("bundle", "json");

         //using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8787", form))
         using (UnityWebRequest www = UnityWebRequest.Get(url))
         {
             //var request = new UnityWebRequest(url, "POST");
             //byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
             //www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
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
                 persiste.u = JsonUtility.FromJson<User>(js);
                 Debug.Log(persiste.u.ToString());
                 SceneManager.LoadScene("SampleScene");
             }
         }
     }

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HacerLogin()
    {
        Debug.Log("usr:" + usr.text);
        Debug.Log("pwd:" + pwd.text);
        //User u = new User();
        persiste.u.id = 1;
        persiste.u.userId = 2;
        persiste.u.body = usr.text;
        persiste.u.title = pwd.text;
        string url = "http://localhost:8787?id="+persiste.u.id;
        url += "&userId="+persiste.u.userId;
        url += "&body="+persiste.u.body;
        url += "&title="+persiste.u.title;
        Debug.Log(url);
        StartCoroutine(Upload(url));
        
    }
}


















