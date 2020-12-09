using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Orders;
using Assets.Scripts.Orders.Units;
using Assets.Scripts.Units;
using Assets.Scripts.UnitsControlScripts;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaskAssigner : MonoBehaviour
{
    public List<Unit> SelectedUnits;
    public Player thisPlayer;
    public PlayerInput playerInput;

    #region CachedData

    private List<Unit> CachedSelectedUnits;

    #endregion
    
    private void Update()
    {
        if (CachedSelectedUnits != SelectedUnits)
        {
            CachedSelectedUnits = SelectedUnits;
            UpdateSelectedUnits();
        }
    }

    void UpdateSelectedUnits()
    {
        for (int i = 0; i < SelectedUnits.Count; i++)
        {
            if (SelectedUnits[i] == null)
            {
                SelectedUnits.RemoveAt(i);
                i--;
            }
        }
    }


    public void OnEnable()
    {
        SelectedUnits = new List<Unit>();
    }

    public void OnSetOrder()
    {
        Vector2 mousePosition = playerInput.actions.FindActionMap("MainControl").FindAction("MousePosition")
            .ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(typeof(FractionMember), out Component component))
            {
                if (((FractionMember) component).fraction != thisPlayer.fraction)
                {
                    foreach (Unit unit in SelectedUnits)
                    {
                        if(unit == null) continue;
                        
                        AttackTask attackTask = new AttackTask(hit.transform.gameObject, unit.gameObject);
                        thisPlayer.orderSender.CmdSendOrder(unit.GetComponent<NetworkIdentity>(), attackTask);
                    }

                    return;
                }
            }

            foreach (Unit unit in SelectedUnits)
            {
                if(unit == null) continue;
                
                MoveTask moveTask = new MoveTask(hit.point, SelectedUnits.Count, unit.gameObject);
                thisPlayer.orderSender.CmdSendOrder(unit.GetComponent<NetworkIdentity>(), moveTask);
            }
        }
    }

    public void OnSelectUnit()
    {
        Vector2 mousePosition = playerInput.actions.FindActionMap("MainControl").FindAction("MousePosition")
            .ReadValue<Vector2>();
        
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(typeof(FractionMember), out Component component))
            {
                if (((FractionMember) component).fraction == thisPlayer.fraction)
                {
                    SelectedUnits = new List<Unit> {hit.transform.gameObject.GetComponent<Unit>()};
                    return; 
                }
            }
        }

        SelectedUnits = new List<Unit>();
    }

    

}
