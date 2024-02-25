using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class BellSounds : MonoBehaviour
    {
        [SerializeField] private AudioClip _bellSound;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayBellRinging()
        {
            _audioSource.PlayOneShot(_bellSound);
        }
    }
}
