using System;
using UnityEngine;

namespace StateMashine.States
{
    public class ButtonStateMashine : MonoBehaviour
    {
        [SerializeField] private MonoState[] states = Array.Empty<MonoState>();

        private int _currentStateIndex;

        private void Start() => Initialize();

        public void ChangeOnNextState()
        {
            _currentStateIndex = GetNextStateIndex(_currentStateIndex);
            states[_currentStateIndex].Enter();
        }

        private void Initialize()
        {
            if (states.Length == 0)
            {
                throw new InvalidOperationException(("States should be initialized"));
                enabled = false;
            }
            _currentStateIndex = 0;
            states[_currentStateIndex].Enter();
        }

        private int GetNextStateIndex(int currentIndex) => (currentIndex + 1) % states.Length;
    }
}