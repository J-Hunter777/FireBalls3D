using System;
using UnityEngine;

namespace StateMashine.States
{
    public class ButtonStateMashine : MonoBehaviour
    {
        [SerializeField] private MonoState[] _states = Array.Empty<MonoState>();

        private int _currentStateIndex;

        private void Start() => Initialize();

        public void ChangeOnNextState()
        {
            _currentStateIndex = GetNextStateIndex(_currentStateIndex);
            _states[_currentStateIndex].Enter();
        }

        private void Initialize()
        {
            if (_states.Length == 0)
            {
                throw new InvalidOperationException(("States should be initialized"));
                enabled = false;
            }
            _currentStateIndex = 0;
            _states[_currentStateIndex].Enter();
        }

        private int GetNextStateIndex(int currentIndex) => (currentIndex + 1) % _states.Length;
    }
}