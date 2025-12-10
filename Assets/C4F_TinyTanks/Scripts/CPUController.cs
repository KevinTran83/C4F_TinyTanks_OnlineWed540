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
        private HP _target;

        private void Start() { _agent = GetComponent<NavMeshAgent>(); }

        private void Update()
        {
            if (!_turret)          return;
            if (!_shoot )          return;
            
            Move();

            if (!HasFoundTarget()) return;

            Fire();
            Aim();
        }

        private void Fire()
        {
            if (_shootRoutine != null) return;

            _shootRoutine = StartCoroutine("DoShoot");
        } 
        private void Move()
        {
            Vector3 dest = transform.position + Random.insideUnitSphere * _moveRange;
            if ( _agent.remainingDistance <= 0.05f
              && NavMesh.SamplePosition(dest, out NavMeshHit hit, 1, NavMesh.AllAreas)
               ) _agent.SetDestination(hit.position);
        } 
        private void Aim() { _turret.Turn(_target.transform.position); } 

        private float SecondsPerRound() { return 60.0f / _rpm; }
        private IEnumerator DoShoot()
        {
            _shoot.Fire();
            yield return new WaitForSeconds(SecondsPerRound());
            _shootRoutine = null; // Finishes the routine so the CPU can shoot again.
        }

        private bool HasFoundTarget()
        {
            if (_target && !_target.IsEmpty()) return true;

            Collider[] nearbyEnemies = Physics.OverlapSphere(transform.position,
                                                             50.0f
                                                            );
            foreach (Collider enemy in nearbyEnemies)
            {
                if (enemy.gameObject == gameObject) continue;
                _target = enemy.GetComponent<HP>();
                if (!_target) continue;
                return true;
            }

            return false;
        }
    }
}