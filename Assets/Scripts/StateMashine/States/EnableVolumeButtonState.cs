using UnityEngine.Audio;

namespace StateMashine.States
{
    public class EnableVolumeButtonState : ConfigureVolumeButtonState
    {
        protected override float VolumeLevel => 0.0f;
    }
}