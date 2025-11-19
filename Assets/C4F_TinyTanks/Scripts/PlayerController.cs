using UnityEngine;
using UnityEngine.AI;

namespace Code4Fun.TinyTanks
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    { 
        private NavMeshAgent _agent;
        [SerializeField] private Turret _turret;
        [SerializeField] private Shoot  _shoot;

        private void Start()
        {
            _agent  = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!_turret) return;
            if (!_shoot)  return;

            Fire();

            if (!Physics.Raycast
            (
                Camera.main.ScreenPointToRay(Input.mousePosition),
                out RaycastHit hit
            )) return;

            Move(hit.point);
            Aim (hit.point);
        }

        private void Fire()
        {
            if (Input.GetMouseButtonDown(0))
                _shoot.Fire();
        }

        private void Move(Vector3 targetPos)
        {
            if (Input.GetMouseButtonDown(1))
                _agent.SetDestination(targetPos);
        }

        private void Aim(Vector3 targetPos)
        {
            _turret.Turn(targetPos);
        }
    }
}