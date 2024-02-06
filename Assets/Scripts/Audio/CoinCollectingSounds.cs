using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinCollectingSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] _coinPickupSounds;

    private AudioSource _audioSorce;

    private void Start()
    {
        _audioSorce = GetComponent<AudioSource>();
    }

    public void PlayCoinPickup()
    {
        int soundIndex = Random.Range(0, _coinPickupSounds.Length);
        _audioSorce.PlayOneShot(_coinPickupSounds[soundIndex]);
    }
}