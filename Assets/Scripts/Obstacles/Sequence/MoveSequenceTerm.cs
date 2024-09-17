using System.Collections;
using Scripts.Structures;
using UnityEngine;

namespace Obstacles.Sequence
{
    public class MoveSequenceTerm : IMovementSequenceTerm
    {
        private readonly IMovement _movement;
        private readonly FloatRange _duratin;

        public MoveSequenceTerm(IMovement movement, FloatRange duratin)
        {
            _movement = movement;
            _duratin = duratin;
        }
        
        public IEnumerator GetSequenceTermCoroutine()
        {
            float enteredTime = Time.time;
            float duration = _duratin.Random;
            float speed = _movement.Speed;

            while (Time.time < enteredTime + duration)
            {
                _movement.Move(speed);
                yield return null;
            }
        }
    }
}