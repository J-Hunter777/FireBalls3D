using UnityEngine;

namespace StateMashine
{
    public abstract class MonoState : MonoBehaviour, IState
    {
        public abstract void Enter();
        
    }
}