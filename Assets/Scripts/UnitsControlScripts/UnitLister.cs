using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UnitsControlScripts.UnitsControlScripts
{
    public class UnitLister : MonoBehaviour
    {
        public List<GameObject> units;


        #region CachedData

        private List<GameObject> cachedUnits;

        #endregion
        private void Update()
        {
            if (cachedUnits != units)
            {
                UpdateUnitsList();
                cachedUnits = units;
            }
            
        }

        private void UpdateUnitsList()
        {
            for (int i = 0; i < units.Count; i++)
            {
                if(units[i] == null)
                    units.RemoveAt(i);
            }
        }
    }
}
