using UnityEngine;
using UnityEngine.UI;

namespace StateMashine.States
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class IconChangeButtonState : MonoState
    
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private AudioClip clickSound;
        private Image _image;
        private AudioSource _audioSource;

        private void Start()
        {
            _image = GetComponent<Image>();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.mute = true;
            
        }

        public override void Enter()
        {
            _image.sprite = icon;
            _audioSource.PlayOneShot(clickSound);
            _audioSource.mute = false;
            OnStateEnter();
        }

        protected virtual void OnStateEnter()
        {
            
        }
    }
}