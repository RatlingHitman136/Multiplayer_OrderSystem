using Assets.Scripts.UnitsControlScripts;
using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Orders.Units
{
    public class MoveAttackTask : GameOrder
    {
        private Vector3 destination;
        private int numOfUnits;
        private GameObject target;

        public MoveAttackTask(Vector3 destination, int numOfUnits,GameObject ObjectToOrder) : base(ObjectToOrder)
        {
            this.destination = destination;
            this.numOfUnits = numOfUnits;
        }

        public override void StartOrder()
        {
            base.StartOrder();
            if (ObjectToOrder.TryGetComponent(typeof(Unit), out Component component))
            {
                Unit unit = component as Unit;
                unit.agent.SetDestination(destination + new Vector3(Random.value*0.21f,0,Random.value*0.21f)*numOfUnits);
            }
        }

        public override void UpdateOrder()
        {
            if (ObjectToOrder.TryGetComponent(typeof(Warrior), out Component component))
            {
                Warrior thisUnit = component as Warrior;
                if (Vector3.Distance(thisUnit.transform.position, destination) <= thisUnit.reachDistance)
                {
                    StopOrder();
                    return;
                }

                if (target == null)
                {
                    GameObject bestTarget = UpdateTarget(thisUnit);
                    if (bestTarget != null)
                    {
                        thisUnit.agent.SetDestination(bestTarget.transform.position);
                        target = bestTarget;
                    }
                    else
                    {
                        if (thisUnit.agent.destination != destination)
                        {
                            float offset = numOfUnits * 0.21f;
                            thisUnit.agent.SetDestination(destination +
                                                          new Vector3(Random.Range(-offset, offset), 0,
                                                              Random.Range(-offset, offset)));
                        }
                    }
                }
                else if (Vector3.Distance(thisUnit.transform.position, target.transform.position) <= thisUnit.attackDistance)
                {
                    Attack(thisUnit);
                }
                
            }
        }

        public override void StopOrder()
        {
            base.StopOrder();
            if (ObjectToOrder.TryGetComponent(typeof(Unit), out Component component))
            {
                Unit unit = component as Unit;
                unit.agent.isStopped = true;
                return;
            }
        }

        #region Additional methods

        private GameObject UpdateTarget(Warrior thisUnit)
        {
            float smallestDst = float.MaxValue;
            GameObject o = null;
            foreach (GameObject g in thisUnit.fractionMember.lister.units)
            {
                float d = Vector3.Distance(thisUnit.transform.position, g.transform.position);
                if (g.GetComponent<FractionMember>().fraction != thisUnit.fractionMember.fraction && d < smallestDst &&
                    d < thisUnit.visionDistance)
                {
                    smallestDst = d;
                    o = g;
                }
            }

            return o;
        }

        private void Attack(Warrior thisUnit)
        {
            thisUnit.transform.LookAt(target.transform.position);
            target.GetComponent<DamageSystem>().TakeDamage(thisUnit.damagePerSecond * Time.deltaTime);
        }

        #endregion
    }
}
