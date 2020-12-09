using System;
using Assets.Scripts.UnitsControlScripts;
using Assets.Scripts.Units;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Orders.Units
{
    [Serializable]
    public class AttackTask : GameOrder
    {
        public GameObject target { get; private set; }

        public AttackTask (GameObject t, GameObject ObjectToOrder):base(ObjectToOrder)
        {
            target = t;
        }

        public override void StartOrder()
        {
            base.StartOrder();
            if (ObjectToOrder.TryGetComponent(typeof(Unit), out Component component))
            {
                Unit unit = component as Unit;
                unit.agent.SetDestination(target.transform.position);
            }
        }

        public override void UpdateOrder()
        {
            if (target == null)
            {
                StopOrder();
                return;
            }
            
            
        
            if (ObjectToOrder.TryGetComponent(typeof(Warrior), out Component component))
            {
                Warrior unit = component as Warrior;

                unit.agent.SetDestination(target.transform.position);
                
                if (Vector3.Distance(unit.transform.position, target.transform.position) <= unit.attackDistance)
                {
                    Attack(unit);
                    return;
                }
                if (Vector3.Distance(unit.transform.position, target.transform.position) <= unit.reachDistance)
                {
                    unit.agent.SetDestination(unit.transform.position);
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

        #region Additional methods

        private void Attack(Warrior thisUnit)
        {
            thisUnit.transform.LookAt(target.transform.position);
            target.GetComponent<DamageSystem>().TakeDamage(thisUnit.damagePerSecond * Time.deltaTime);
        }

        #endregion
    }
}