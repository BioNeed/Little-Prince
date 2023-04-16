using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class MovementSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] _jumpSounds;
    [SerializeField] private AudioClip _pullingClothSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        int index = Random.Range(0, _jumpSounds.Length);
        _audioSource.PlayOneShot(_jumpSounds[index]);
    }

    public void PlayPullingSound()
    {
        _audioSource.clip = _pullingClothSound;
        _audioSource.Play();
    }

    public void StopPullingSound()
    {
        _audioSource.Stop();
    }
}
