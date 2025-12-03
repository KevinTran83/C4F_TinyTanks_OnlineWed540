using UnityEngine;
using UnityEngine.Events;

namespace Code4Fun.TinyTanks
{
    public class HP : MonoBehaviour
    {
        [SerializeField] private float _maxHP = 10;

        private float _remainingHP;

        [SerializeField] private UnityEvent _onDeath;

        private void Start()
        {
            _remainingHP = _maxHP;
        }

        public void Deplete(float amount)
        {
            _remainingHP -= amount;
            if (_remainingHP <= 0)   { _remainingHP = 0;
                                       _onDeath.Invoke();
                                     }
            if (_remainingHP > _maxHP) _remainingHP = _maxHP;
        }

        public bool IsEmpty() { return _remainingHP == 0; }
    }
}