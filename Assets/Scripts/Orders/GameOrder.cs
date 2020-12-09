using System;
using UnityEngine;

namespace Assets.Scripts.Orders
{
    [Serializable]
    public class GameOrder{
        public bool isPefrormed { get; private set; } = false;
        public GameObject ObjectToOrder;

        public GameOrder(GameObject ObjectToOrder)
        {
            this.ObjectToOrder = ObjectToOrder;
        }

        public virtual void StartOrder()
        {
            isPefrormed = true;
        }

        public virtual void UpdateOrder()
        { }

        public virtual void StopOrder()
        {
            isPefrormed = false;
        }
    }
}