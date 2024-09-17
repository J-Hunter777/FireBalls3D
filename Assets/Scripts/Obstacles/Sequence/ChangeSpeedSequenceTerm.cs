using System.Collections;
using Obstacles.Sequence;
using Scripts.Structures;
using UnityEngine;

namespace Scripts.Obstacles
{
    public class ChangeSpeedSequenceTerm : IMovementSequenceTerm
    {
        private const float PositiveSpeedChangePercent = 0.5f;
        private FloatRange _speed;
        private FloatRange _duration;
        private IMovement _movement;
        private AnimationCurve _curve;

        public ChangeSpeedSequenceTerm(IMovement movement, FloatRange speed, FloatRange duration, AnimationCurve curve)
        {
            _movement = movement;
            _speed = speed;
            _duration = duration;
            _curve = curve;
        }

        public IEnumerator GetSequenceTermCoroutine()
        {
            float enteredTime = Time.time;
            float duration = _duration.Random;
            float enteredSpeed = _movement.Speed;
            float newSpeed = ChooseSpeed(_speed);

            while (Time.time < enteredTime + duration)
            {
                float elapsedTimePercent = (Time.time - enteredTime) / duration;
                float difference = newSpeed - enteredSpeed;
                float scaleDifference = difference * _curve.Evaluate(elapsedTimePercent);
                float speed = enteredSpeed + scaleDifference;
                _movement.Move(speed);
                yield return null;

            }
        }
        private float ChooseSpeed(FloatRange speed)
        {
            return Random.value > PositiveSpeedChangePercent 
                ? speed.Random 
                : -speed.Random;
    }
}

}