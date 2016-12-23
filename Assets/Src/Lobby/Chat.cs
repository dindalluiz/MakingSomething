using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class Chat : MonoBehaviour
{
    static SocketIOComponent server;

    public static void StartListen(SocketIOComponent so)
    {
        server = so;
        Network_Helper.ListenOperation(so, "ReceiveMessage", ReceiveMessage);
        Debug.Log("startou a ouvido");
    }

    public void Send()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["channel"] = "Lobby";
        data["sendMessage"] = GlobalReferences.InputMessageArea.text;
        Network_Helper.SendOperation(server, "SendMessage", data);
    }

    private static void ReceiveMessage(SocketIOEvent e)
    {
        Debug.Log("penis:"+e.data.GetField("message").str);
        GlobalReferences.TxtMessagesStatic.text += e.data.GetField("message").str+"\n";
    }
}
