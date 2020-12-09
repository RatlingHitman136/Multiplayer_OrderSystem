using UnityEngine;

namespace Assets.Scripts.UnitsControlScripts
{
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField]
        private float hp;

        public void TakeDamage(float value)
        {
            hp -= value;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
