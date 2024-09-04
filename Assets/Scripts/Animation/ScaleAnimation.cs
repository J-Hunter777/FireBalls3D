using DG.Tweening;
using TweenStructures;
using UnityEngine;


namespace Animation
{
    public class ScaleAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3TweenData tweenData;
        

        private void Start() =>
            ApplayAnimation(tweenData);

     private void ApplayAnimation(Vector3TweenData _tweenData) =>
            transform
                    .DOScale(_tweenData.EndValue, _tweenData.Duration)
                    .SetEase(_tweenData.Ease)
                    .SetLoops(-1, LoopType.Yoyo);


    }   
}