using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class UserList : MonoBehaviour
{
    static SocketIOComponent socket;

    public static void RefreshList(SocketIOComponent server)
    {
        socket = server;
        Debug.Log("vem piranha");
        Network_Helper.ListenOperation(server, "GetUsers", FeedList);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Network_Helper.SendOperation(socket, "MyIDLobby");
            Debug.Log("MEU ID NESSA PORRA E: " + GlobalReferences.ID);
        }
    }

    private static void FeedList(SocketIOEvent e)
    {
        string str = e.data.GetField("users").str;
        str = str.Replace(",", "\n");

        GlobalReferences.TxtUsersList.text = str;
    }
}
