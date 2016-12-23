using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SocketIO;

public class Network_Manager : MonoBehaviour
{
    [SerializeField]
    private  GameObject lobbyGO, chatGO, roomsGO, gameGO;

    private SocketIOComponent lobbySocket, chatSocket, roomsSocket, gameSocket;

    public bool lobbyConnected, chatConnected;

    void Awake ()
    {
        lobbyGO = Instantiate(lobbyGO);
        chatGO  = Instantiate(chatGO);
        roomsGO = Instantiate(roomsGO);
        gameGO  = Instantiate(gameGO);
    }

    private void Start()
    {
        lobbySocket = lobbyGO.GetComponent<SocketIOComponent>();
        chatSocket = chatGO.GetComponent<SocketIOComponent>();
        roomsSocket = roomsGO.GetComponent<SocketIOComponent>();
        gameSocket = gameGO.GetComponent<SocketIOComponent>();
    }
 

    public void Connect(Network_Helper.Servers sr)
    {
        switch(sr)
        {
            case Network_Helper.Servers.lobby:
                lobbySocket.Connect();

                lobbySocket.On("open", OnLobbyOpen);
                break;

            case Network_Helper.Servers.chat:
                chatSocket.Connect();

                chatSocket.On("open", OnChatOpen);
                break;

            case Network_Helper.Servers.rooms:
                roomsSocket.Connect();
            break;

            case Network_Helper.Servers.game:
                gameSocket.Connect();
            break;
        }
    }

    public void Disconnect(Network_Helper.Servers sr)
    {
        switch (sr)
        {
            case Network_Helper.Servers.lobby:
                lobbySocket.Close();
                break;

            case Network_Helper.Servers.chat:
                chatSocket.Close();
                break;

            case Network_Helper.Servers.rooms:
                roomsSocket.Close();
                break;

            case Network_Helper.Servers.game:
                gameSocket.Close();
                break;
        }
    }

    public SocketIOComponent getServer(Network_Helper.Servers sr)
    {
        switch (sr)
        {
            case Network_Helper.Servers.lobby:
                return lobbySocket;
                break;

            case Network_Helper.Servers.chat:
                return chatSocket;
                break;

            case Network_Helper.Servers.rooms:
                return roomsSocket;
                break;

            case Network_Helper.Servers.game:
                return gameSocket;
                break;
        }

        return null;
    }

    public void OnLobbyOpen(SocketIOEvent e)
    {
        //Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
        lobbyConnected = true;
    }
    public void OnChatOpen(SocketIOEvent e)
    {
        //Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
        chatConnected = true;
        chatSocket.sid = GlobalReferences.ID;
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["id"] = GlobalReferences.ID;
        Network_Helper.SendOperation(chatSocket, "MyIDChat", data);
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
