using UnityEngine;

namespace Code4Fun.TinyTanks
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject _proj;
        [SerializeField] private Transform  _muzzle;

        private bool _canShoot = true;

        public void Fire() { if (!_canShoot) return;
                             Instantiate(_proj, _muzzle.position, _muzzle.rotation);
                           }

        public void HoldFire() { _canShoot = false; }
    }
}