using System;
using System.Collections.Generic;
using Assets.Scripts.Orders.Units;
using Assets.Scripts.UnitsControlScripts;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units
{
    [RequireComponent(typeof(OrderableObject), typeof(FractionMember),typeof(NetworkIdentity))]
    public class Unit : MonoBehaviour
    {
        public float reachDistance { get; protected set; }
        
        public NavMeshAgent agent { get; protected set; }
        public FractionMember fractionMember { get; protected set; }
        public OrderableObject orderableObject { get; private set; }

        private void Start()
        {
            reachDistance = .1f;

            BaseUnitInitialization();
            
            orderableObject.SetPossibleOrderTypes(new List<Type> {typeof(MoveTask)});
        }

        protected void BaseUnitInitialization()
        {
            orderableObject = GetComponent<OrderableObject>();
            fractionMember = GetComponent<FractionMember>();
            agent = GetComponent<NavMeshAgent>();
        }

    }
}
