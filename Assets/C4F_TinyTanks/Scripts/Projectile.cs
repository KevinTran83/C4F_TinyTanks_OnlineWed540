using UnityEngine;

namespace Code4Fun.TinyTanks
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed  = 20;

        private void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * _speed;
            Invoke("SelfDestruct", 5.0f);
        }

        public void SelfDestruct() { Destroy(gameObject); }
    }
}