using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Code4Fun.TinyTanks
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CPUController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        [SerializeField] private Turret _turret;
        [SerializeField] private Shoot  _shoot;
        [SerializeField] private float  _moveRange  = 10;
        [SerializeField] private float  _shootRange = 20;
        [SerializeField] private int    _rpm        = 100;

        private Coroutine _shootRoutine;

        private void Start() { _agent = GetComponent<NavMeshAgent>(); }

        private void Update()
        {
            if (!_turret) return;
            if (!_shoot ) return;

            Fire();
            Move();
            Aim();
        }

        private void Fire()
        {
            if (_shootRoutine != null) return;

            _shootRoutine = StartCoroutine("DoShoot");
        } 
        private void Move() { } 
        private void Aim() { } 

        private float SecondsPerRound() { return 60.0f / _rpm; }
        private IEnumerator DoShoot()
        {
            _shoot.Fire();
            yield return new WaitForSeconds(SecondsPerRound());
            _shootRoutine = null; // Finishes the routine so the CPU can shoot again.
        }
    }
}