using UnityEngine;
using UnityEngine.Audio;

namespace StateMashine.States
{
    public abstract class ConfigureVolumeButtonState : IconChangeButtonState
    {
        [Header("Volume Settings")]
        [SerializeField] private string volumeExposedParameter;
        [SerializeField] private AudioMixer audioMixer;
        protected abstract float VolumeLevel { get; }

        protected override void OnStateEnter()
        {
            audioMixer.SetFloat(volumeExposedParameter, VolumeLevel);
        }
    }
}