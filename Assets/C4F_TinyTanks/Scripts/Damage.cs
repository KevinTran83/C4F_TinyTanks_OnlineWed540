using UnityEngine;

namespace Code4Fun.TinyTanks
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private float _damage = 3;

        private void OnCollisionEnter(Collision col)
        {
            HP hp = col.gameObject.GetComponent<HP>();
            if (!hp) return;

            hp.Deplete(_damage);
            Destroy(gameObject);
        }
    }
}