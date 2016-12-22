using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Network_Helper
{
    static string[] transport;

    public enum Servers
    {
        lobby,
        chat,
        rooms,
        game
    }

    public static void SendOperation(SocketIOComponent so, string operation, Dictionary<string, string> data)
    {
        so.Emit(operation, new JSONObject(data));
    }

    public static void SendOperation(SocketIOComponent so, string operation)
    {
        so.Emit(operation);
    }

    public static void ListenOperation(SocketIOComponent so, string operation, System.Action<SocketIOEvent> e)
    {
        so.On(operation, e);
    }
}
