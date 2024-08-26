using System.Collections;
using UnityEngine;

namespace Animation
{
   
    public class SizeAnimayion : MonoBehaviour 
	{
        [SerializeField] private Vector3 _scaleFrom;
        [SerializeField] private Vector3 _scaleTo;
        [SerializeField] [Min(0.0f)] private float _duration;
        [SerializeField] private AnimationCurve _scaleCurve;
        private void Start() => 
            StartCoroutine(PlayLoopedScalingAnimation(transform, _scaleFrom, _scaleTo, _duration, _scaleCurve));

        private IEnumerator PlayLoopedScalingAnimation(Transform transformToAnimate, Vector3 from, Vector3 to, float duration, AnimationCurve scaleCurve)
        {
            while (true)
            {
                yield return StartCoroutine(PlayScalingAnimation(transformToAnimate, to, duration, _scaleCurve));
                yield return StartCoroutine(PlayScalingAnimation(transformToAnimate, from, duration, _scaleCurve));
            }
        }
        private IEnumerator PlayScalingAnimation(Transform transformToAnimate, Vector3 to,  float duration, AnimationCurve scaleCurve)
        {
            float enteredTime = Time.time;
            Vector3  enteredScale = transformToAnimate.localScale;
            while (Time.time < enteredTime + duration)
            {
                float elapsedTimePercent = (Time.time - enteredTime) / duration;
                Vector3 difference = to - enteredScale;
                Vector3 scaledDifference = scaleCurve.Evaluate(elapsedTimePercent) * difference;
                transform.localScale = enteredScale + scaledDifference;
                yield return null;
            }
        }
    }
}
