using System;
using Assets.Scripts.Units;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Orders.Units
{
    [Serializable]
    public class MoveTask : GameOrder
    {
        public Vector3 destination { get;private set; }
        public int numOfUnits { get;private set; }

        public MoveTask(Vector3 destination, int numOfUnits,GameObject ObjectToOrder) : base(ObjectToOrder)
        {
            this.destination = destination;
            this.numOfUnits = numOfUnits;
        }

        public override void StartOrder()
        {
            base.StartOrder();

            if (ObjectToOrder.TryGetComponent(typeof(Unit), out Component component))
            {
                Unit thisUnit = component as Unit;
                float offset = numOfUnits * 0.21f;
                thisUnit.agent.SetDestination(destination +
                                          new Vector3(Random.Range(-offset, offset), 0,
                                              Random.Range(-offset, offset)));
            }
        }

        public override void UpdateOrder()
        {
            if (ObjectToOrder.TryGetComponent(typeof(Unit), out Component component))
            {
                Unit unit = component as Unit;
                if (Vector3.Distance(unit.transform.position, destination) <= unit.reachDistance)
                {
                    StopOrder();
                    return;
                }
            }
        }

        public override void StopOrder()
        { 

            base.StopOrder();
            if (ObjectToOrder.TryGetComponent(typeof(Unit), out Component component))
            {
                Unit unit = component as Unit;
                unit.agent.SetDestination(unit.transform.position);
                return;
            }
        }
    }
}