using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class Network_Manager : MonoBehaviour
{
    [SerializeField]
    SocketIOComponent socket;

    [SerializeField]
    GameObject infoObj;

    Text info;

    string id;

    void Start ()
    {
        info = infoObj.GetComponent<Text>();
        socket.On("open", OnOpen);
        socket.On("error", OnError);
        socket.On("close", OnClose);
    }

    void Update()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["login"] = "user";
        data["pass"] = "123";

        if (Input.GetKeyDown(KeyCode.A))
        {
            socket.Emit("login", new JSONObject(data), Login);
            Debug.Log("apertei");
        }
    }

    public void Login(JSONObject e)
    {
        if (e.GetField("message").str == "true")
        {
            this.info.text += "\nLogadão nessa caralha";
        }
        else
        {
            this.info.text += "\nSe fudeu";
        }

        Debug.Log("buceta");
    }

    public void OnOpen(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
        id = socket.sid;
        this.info.text += "\nID:" + id;
    }

    public void OnError(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
    }

    public void OnClose(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
    }
}
