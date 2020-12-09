using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FractionSelectionManager : NetworkBehaviour
{
    public List<NetworkIdentity> FractionButtons;
    public NetworkIdentity SubmitionButton;
    
    public NetworkManager manager;

    public PlayerInput playerInput;
    
    public int SubmitedPlayersCount;
    

    [SyncVar]
    public bool isAllReady = false;

    private void Awake()
    {
        manager = GameObject.FindWithTag("NetworkManager").GetComponent<NetworkManager>();
    }

    private void Update()
    {
        if (SubmitedPlayersCount == manager.maxConnections)
            isAllReady = true;
        
        if (isAllReady)
        {
            playerInput.SwitchCurrentActionMap("MainControl");
            this.gameObject.SetActive(false);
        }

        if(isServer)
            CmdSomeFunction();
    }

    public void DeactivateChosenFraction(int FractionIndex)
    {
        for (int i = 0; i < FractionButtons.Count; i++)
        {
            if (i + 1 == FractionIndex)
            {
                FractionButtons[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                FractionButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ServerSubmitPlayersFraction()
    {
        SubmitedPlayersCount++;
    }
    public void ClientSubmitPlayersFraction()
    {
        SubmitionButton.GetComponent<Button>().interactable = false;
    }

    [ClientRpc]
    void CmdSomeFunction()
    {
        Debug.Log("Some text");
    }
}
