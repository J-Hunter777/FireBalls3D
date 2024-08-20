using DG.Tweening;
using UnityEngine;
using System;

namespace Assets.Scripts.Animation
{
    public class ScaleAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 _scaleTo;
        [SerializeField][Min(0.0f)] private float _duration;
        [SerializeField] private AnimationCurve _scaleCurve;

        private void Start() 
        {
            ApplayAnimation();
        }

        private void ApplayAnimation() =>
            transform
                    .DOScale(_scaleTo, _duration)
                    .SetEase(_scaleCurve)
                    .SetLoops(-1, LoopType.Yoyo);


    }
}