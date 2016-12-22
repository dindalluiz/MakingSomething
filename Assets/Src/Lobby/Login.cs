using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class Login : MonoBehaviour
{
    SocketIOComponent serverLobby, serverChat;

    public void LoginButton()
    {
        GlobalReferences.NetworkManager.Connect(Network_Helper.Servers.lobby);
        GlobalReferences.NetworkManager.Connect(Network_Helper.Servers.chat);
        StartCoroutine(login());
        StartCoroutine(chat());
    }

    IEnumerator login()
    {
        while (GlobalReferences.NetworkManager.lobbyConnected == false)
        {
            yield return null;
        }
        serverLobby = GlobalReferences.NetworkManager.getServer(Network_Helper.Servers.lobby);

        Dictionary<string, string> data = new Dictionary<string, string>();
        data["name"] = GlobalReferences.TxtNick.text.ToString();

        Network_Helper.SendOperation(serverLobby, "SetName", data);
        Network_Helper.SendOperation(serverLobby, "GetUsers");

        UserList.RefreshList(serverLobby);

        GlobalReferences.PanelNick.SetActive(false);
        GlobalReferences.PanelLobby.SetActive(true);
    }

    IEnumerator chat()
    {
        while (GlobalReferences.NetworkManager.chatConnected == false)
        {
            yield return null;
        }
        serverChat = GlobalReferences.NetworkManager.getServer(Network_Helper.Servers.chat);
        Chat.StartListen(serverChat);
    }
}