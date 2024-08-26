﻿using System;
using UnityEngine;
using StateMashine;
using UnityEngine.UI;

namespace StateMashine.States
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class IconChangeButtonState : MonoState
    
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private AudioClip _clickSound;
        private Image _image;
        private AudioSource _audioSource;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.mute = true;
        }

        public override void Enter()
        {
            _image.sprite = _icon;
            _audioSource.PlayOneShot(_clickSound);
            _audioSource.mute = false;
            OnStateEnter();
        }

        protected virtual void OnStateEnter()
        {
            
        }
    }
}