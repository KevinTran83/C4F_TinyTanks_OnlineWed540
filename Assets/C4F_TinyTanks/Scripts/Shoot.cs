using UnityEngine;

namespace Code4Fun.TinyTanks
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _proj;
        [SerializeField] private Transform  _muzzle;

        public void Fire() { Instantiate(_proj, _muzzle.position, _muzzle.rotation);
                           }
    }
}