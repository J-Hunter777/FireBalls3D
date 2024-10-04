using DG.Tweening;
using TweenStructures;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Serialization;

namespace Animation
{
    public class SettingsButtonDropdownAnimation : MonoBehaviour
    {
        [SerializeField] private Vector2RangedTweenData buttonsTweenData;
        [SerializeField] private GameObject actionRoot;
        [SerializeField] private float delayBetweenButtons;

        private RectTransform[] _buttonTransforms;
        private bool _active;
        

        private void Start()
        {
            _buttonTransforms = actionRoot.GetComponentsInChildren<RectTransform>();
            TweenButtonSize(_active, buttonsTweenData);
        }

        public void OnButtonClicked()
        {
            _active = !_active;
            TweenButtonSize(_active, buttonsTweenData);
        }
        private void TweenButtonSize(bool active, Vector2RangedTweenData tweenData)
        {
            float delay = 0.1f;

            foreach (RectTransform buttonTransform in _buttonTransforms)
            {
                Vector2 sizeDelta = active ? tweenData.To : tweenData.From;
                buttonTransform
                    .DOSizeDelta(sizeDelta,tweenData.Duration)
                    .SetDelay(delay)
                    .SetEase(tweenData.Ease);
                delay += delayBetweenButtons;
            }
        }

    }
}
