using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class GlobalReferences : MonoBehaviour
{
    [SerializeField]
    private Network_Manager networkManager;
    private static Network_Manager networkManagerStatic;

    public static string ID;

    [SerializeField]
    private Text txtNick, txtUsersList, txtMessages;
    private static Text txtNickStatic, txtUsersListStatic, txtMessagesStatic;

    [SerializeField]
    private GameObject panelNick, panelLobby;
    private static GameObject panelNickStatic, panelLobbyStatic;

    [SerializeField]
    private InputField inputMessageArea;
    private static InputField inputMessageAreaStatic;

    public static void ChangeID(SocketIOEvent e)
    {
        SocketIOComponent server = networkManagerStatic.getServer(Network_Helper.Servers.lobby);
        server.sid = e.data.GetField("id").str;
        GlobalReferences.ID = server.sid;
        Debug.Log("veio: " + e.data.GetField("oid").str);
        Debug.Log("veio: " + e.data.GetField("porra").str);
    }

    private void Start()
    {
        networkManagerStatic    = networkManager;
        txtNickStatic           = txtNick;
        txtUsersListStatic      = txtUsersList;
        panelNickStatic         = panelNick;
        panelLobbyStatic        = panelLobby;
        inputMessageAreaStatic  = inputMessageArea;
        txtMessagesStatic       = txtMessages;
    }

    #region GET/SET
    public static Network_Manager NetworkManager
    {
        get
        {
            return networkManagerStatic;
        }

        set
        {
            networkManagerStatic = value;
        }
    }

    public static Text TxtNick
    {
        get
        {
            return txtNickStatic;
        }

        set
        {
            txtNickStatic = value;
        }
    }

    public static Text TxtUsersList
    {
        get
        {
            return txtUsersListStatic;
        }

        set
        {
            txtUsersListStatic = value;
        }
    }

    public static GameObject PanelNick
    {
        get
        {
            return panelNickStatic;
        }

        set
        {
            panelNickStatic = value;
        }
    }

    public static GameObject PanelLobby
    {
        get
        {
            return panelLobbyStatic;
        }

        set
        {
            panelLobbyStatic = value;
        }
    }

    public static InputField InputMessageArea
    {
        get
        {
            return inputMessageAreaStatic;
        }

        set
        {
            inputMessageAreaStatic = value;
        }
    }

    public static Text TxtMessagesStatic
    {
        get
        {
            return txtMessagesStatic;
        }

        set
        {
            txtMessagesStatic = value;
        }
    }
    #endregion
}
