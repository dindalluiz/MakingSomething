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

    [SerializeField]
    private Text txtNick, txtUsersList;
    private static Text txtNickStatic, txtUsersListStatic;

    [SerializeField]
    private GameObject panelNick, panelLobby;
    private static GameObject panelNickStatic, panelLobbyStatic;

    private void Start()
    {
        networkManagerStatic    = networkManager;
        txtNickStatic           = txtNick;
        txtUsersListStatic      = txtUsersList;
        panelNickStatic         = panelNick;
        panelLobbyStatic        = panelLobby;
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
    #endregion
}
