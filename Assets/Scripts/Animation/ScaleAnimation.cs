using Assets.Scripts.TweenStructures;
using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public class ScaleAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3TweenData _tweenData;
        

        private void Start() 
        {
            ApplayAnimation(_tweenData);
        }

        private void ApplayAnimation(Vector3TweenData tweenData) =>
            transform
                    .DOScale(tweenData.EndValue, tweenData.Duration)
                    .SetEase(tweenData.Ease)
                    .SetLoops(-1, LoopType.Yoyo);


    }
}