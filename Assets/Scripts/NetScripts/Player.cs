using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UnitsControlScripts;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
    
    public OrderSender orderSender;
    private NetworkIdentity fractionSelectionManager;

    [SyncVar]
    public Fraction fraction;
    [SyncVar]
    public bool isReady = false;

    #region Initialization

    [ClientRpc]
    public void RpcInitFractionSelection()
    {
        NetworkIdentity TaskAssigner = GameObject.FindWithTag("TaskAssigner").GetComponent<NetworkIdentity>();
        FractionSelectionManager fractionSelectionManagerScript = GameObject.FindWithTag("FractionSelector").GetComponent<FractionSelectionManager>();
        fractionSelectionManager = GameObject.FindWithTag("FractionSelector").GetComponent<NetworkIdentity>();
        
        for (int i = 0; i < fractionSelectionManagerScript.FractionButtons.Count; i++)
        {
            int FractionIndex = i + 1;
            fractionSelectionManagerScript.FractionButtons[i].GetComponent<Button>().onClick.AddListener(() => this.SetFraction(FractionIndex));
        }
        fractionSelectionManagerScript.SubmitionButton.GetComponent<Button>().onClick.AddListener(this.SubmitFraction);

        if (isLocalPlayer) TaskAssigner.GetComponent<TaskAssigner>().thisPlayer = this;
    }

    #endregion

    #region Preparation
    
    public void SetFraction(int FractionIndex)
    {
        if(!isLocalPlayer) return;
        
        if (!isReady)
        {
            fraction = (Fraction) FractionIndex;
            fractionSelectionManager.GetComponent<FractionSelectionManager>().DeactivateChosenFraction(FractionIndex);
        }
    }

    public void SubmitFraction()
    {
        if (!isLocalPlayer || isReady) return;
        isReady = true;
        CmdSubmitPlayer();
    }

    [Command]
    void CmdSubmitPlayer()
    {
        fractionSelectionManager.GetComponent<FractionSelectionManager>().ServerSubmitPlayersFraction();
        RpcSubmitPlayer();
    }
    [ClientRpc]
    void RpcSubmitPlayer()
    {
        if(isLocalPlayer)
            fractionSelectionManager.GetComponent<FractionSelectionManager>().ClientSubmitPlayersFraction();
    }

    #endregion
    
    
}
