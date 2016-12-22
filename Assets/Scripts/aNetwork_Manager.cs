using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class aNetwork_Manager : MonoBehaviour
{
    [SerializeField]
    SocketIOComponent socket;

    [SerializeField]
    GameObject infoObj;

    private Dictionary<string, string> data;

    Text info;

    string id;

    void Start ()
    {
        info = infoObj.GetComponent<Text>();
        socket.On("open", OnOpen);
        socket.On("error", OnError);
        socket.On("close", OnClose);
        socket.On("updatePos", UpdatePos);
        data = new Dictionary<string, string>();
        data["id"] = socket.sid;
        data["x"] = gameObject.transform.position.x.ToString();
        data["y"] = gameObject.transform.position.y.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            socket.Emit("updatePos", new JSONObject(data));            
            Debug.Log("apertei");
        }
    }

    public void UpdatePos(SocketIOEvent e)
    {
        if (e.data.GetField("message").str == "true")
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
