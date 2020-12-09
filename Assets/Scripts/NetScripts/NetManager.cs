using System;
using Mirror;
using UnityEngine;

public class NetManager : NetworkManager
{
    [Header("Menu references")]
    public GameObject OfflineMenu;
    public GameObject OnlineMenu;
    
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
        player.GetComponent<Player>().RpcInitFractionSelection();
    }

    /*public override void OnClientDisconnect(NetworkConnection conn)
    {
        OnlineMenu.SetActive(false);
        OfflineMenu.SetActive(true);
        this.GetComponent<NetworkManagerHUD>().enabled = false;
        base.OnClientDisconnect(conn);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        OnlineMenu.SetActive(true);
        OfflineMenu.SetActive(false);
        this.GetComponent<NetworkManagerHUD>().enabled = true;
        base.OnClientConnect(conn);
    }*/
}
