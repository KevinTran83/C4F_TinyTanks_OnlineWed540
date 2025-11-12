using UnityEngine;
using UnityEngine.AI;

namespace Code4Fun.TinyTanks
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    { 
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast
                (
                    Camera.main.ScreenPointToRay(Input.mousePosition),
                    out RaycastHit hit
                ))
                {
                    _agent.SetDestination(hit.point);
                }
            }
        }
    }
}