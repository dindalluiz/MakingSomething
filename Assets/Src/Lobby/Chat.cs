using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class Chat : MonoBehaviour
{
    [SerializeField]
    private Network_Manager networkManager;

    [SerializeField]
    private Text txtChat;

    private static Text txtChatReal;

    private void Start()
    {
        txtChatReal = txtChat;
    }

    private void Update()
    {
        txtChat = txtChatReal;
    }

    [SerializeField]
    private InputField inputChat;

    static SocketIOComponent server;

    public static void StartListen(SocketIOComponent so)
    {
        server = so;
        Network_Helper.ListenOperation(so, "Message", ReceiveMessage);
        Debug.Log("startou a ouvido");
    }

    public void Send()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["channel"] = "Lobby";
        data["message"] = this.inputChat.text;
        Network_Helper.SendOperation(server, "Message", data);
    }

    private static void ReceiveMessage(SocketIOEvent e)
    {
        Debug.Log("penis:"+e.data.GetField("message").str);
        txtChatReal.text += e.data.GetField("message").str+"\n";
    }
}
