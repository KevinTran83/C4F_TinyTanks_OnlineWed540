using UnityEngine;

namespace Code4Fun.TinyTanks
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private float _turnSpeed = 100;

        public void Turn(Vector3 targetPos)
        {
            targetPos.y = transform.position.y;
            Quaternion lookRot = Quaternion.LookRotation(targetPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                          lookRot,
                                                          _turnSpeed * Time.deltaTime
                                                         );
        }
    }
}