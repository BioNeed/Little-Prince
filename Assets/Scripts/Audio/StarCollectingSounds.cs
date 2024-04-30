using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StarCollectingSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] _starPickupSounds;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinPickup()
    {
        var soundIndex = Random.Range(0, _starPickupSounds.Length);
        _audioSource.PlayOneShot(_starPickupSounds[soundIndex]);
    }
}