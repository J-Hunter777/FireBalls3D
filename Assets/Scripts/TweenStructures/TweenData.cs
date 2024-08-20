using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.TweenStructures
{
    [System.Serializable]
    public class Vector3TweenData : TweenData<Vector3> { }

    public class TweenData<T>
    {
        public T EndValue;
        public float Duration;
        public Ease Ease;
    }
}