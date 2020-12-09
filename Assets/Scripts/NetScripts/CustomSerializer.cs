using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts.Orders;
using Assets.Scripts.Orders.Units;
using Assets.Scripts.UnitsControlScripts;
using Mirror;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class CustomSerializer
{
    #region OrderSerializer

    enum OrdersIndex : byte
    {
        GameOrder = 0,
        MoveTask = 1,
        AttackTask = 2,
    }

    public static void WriteOrder(this NetworkWriter networkWriter, GameOrder gameOrder)
    {
        OrdersIndex orderType;

        if (!OrdersIndex.TryParse(gameOrder.GetType().Name, out orderType))
        {
            throw (new Exception("Index Enumarator doesn`t have this type"));
        }

        networkWriter.WriteByte((byte)orderType);
        networkWriter.WriteGameObject(gameOrder.ObjectToOrder);
        
        if (orderType == OrdersIndex.MoveTask)
        {
            MoveTask moveTask = gameOrder as MoveTask;
            
            networkWriter.WriteVector3(moveTask.destination);
            networkWriter.WriteInt32(moveTask.numOfUnits);
        }

        if (orderType == OrdersIndex.AttackTask)
        {
            AttackTask attackTask = gameOrder as AttackTask;
            networkWriter.WriteGameObject(attackTask.target);
        }
    }

    public static GameOrder ReadOrder(this NetworkReader networkReader)
    {
        byte OrderIndex = networkReader.ReadByte();

        GameObject ObjecToOrder = networkReader.ReadGameObject();
        
        switch (OrderIndex)
        {
            case 0:
                return new GameOrder(ObjecToOrder);
            case 1:
                Vector3 destination = networkReader.ReadVector3();
                int numOfUnits = networkReader.ReadInt32();
                return new MoveTask(destination,numOfUnits,ObjecToOrder);
            case 2:
                GameObject target = networkReader.ReadGameObject();
                return new AttackTask(target,ObjecToOrder);
            default:
                throw new Exception("ReadOrder doesn`t contain definition for this type");
        }
    }

    #endregion

    #region OrderableObjectSerializer

    public static void WriteOrderableObject(this NetworkWriter networkWriter, OrderableObject orderableObject)
    {
        NetworkIdentity ObjectWithOrderableObject = orderableObject.GetComponent<NetworkIdentity>();
        
        networkWriter.WriteNetworkIdentity(ObjectWithOrderableObject);
    }

    public static OrderableObject ReadOrderableObject(this NetworkReader networkReader)
    {
        NetworkIdentity ObjectWithOrderableObject = networkReader.ReadNetworkIdentity();
        return ObjectWithOrderableObject.GetComponent<OrderableObject>();
    }
    #endregion
    
}
