using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinCollectingSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] _coinPickupSounds;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinPickup()
    {
        int soundIndex = Random.Range(0, _coinPickupSounds.Length);
        _audioSource.PlayOneShot(_coinPickupSounds[soundIndex]);
    }
}