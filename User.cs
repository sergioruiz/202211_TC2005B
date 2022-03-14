using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public int userId;
    public int id;
    public string title;
    public string body;

    public string ToString()
    {
        string txt = "userId: " + userId;
        txt += " id: " + id;
        txt += " title: " + title;
        txt += " body: " + body;
        return txt;
    }
}
