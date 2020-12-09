using Assets.Scripts.UnitsControlScripts.UnitsControlScripts;
using UnityEngine;

namespace Assets.Scripts.UnitsControlScripts
{
    public class FractionMember : MonoBehaviour
    {
        [SerializeField]
        private string unitListerTag;
        [SerializeField]
        public UnitLister lister;
        [SerializeField]
        public Fraction fraction;
        // Start is called before the first frame update
        void Start()
        {
            lister = GameObject.FindGameObjectWithTag(unitListerTag).GetComponent<UnitLister>();
            lister.units.Add(this.gameObject);
        }
        private void OnDestroy()
        {
            lister.units.Remove(this.gameObject);
        }
    }

    public enum Fraction : int
    {
        Player1 = 1,
        Player2 = 2,
    }
}