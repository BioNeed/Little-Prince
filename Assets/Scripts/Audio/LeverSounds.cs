using UnityEngine;

public class LeverSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _leverSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayLeverToggling()
    {
        _audioSource.PlayOneShot(_leverSound);
    }
}
