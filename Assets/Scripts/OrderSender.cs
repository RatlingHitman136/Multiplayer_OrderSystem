using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Orders;
using Assets.Scripts.UnitsControlScripts;
using Mirror;
using UnityEngine;

public class OrderSender : NetworkBehaviour
{
    [Command]
    public void CmdSendOrder(NetworkIdentity ObjectToOrder, GameOrder order)
    {
        ObjectToOrder.GetComponent<OrderableObject>().GiveOrder(order);
        RpcSendOrder(ObjectToOrder,order);
    }

    [ClientRpc]
    public void RpcSendOrder(NetworkIdentity ObjectToOrder, GameOrder order)
    {
        ObjectToOrder.GetComponent<OrderableObject>().GiveOrder(order);
    }
}
