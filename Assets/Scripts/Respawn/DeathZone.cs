using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private VerticalMovement _verticalMovement;
    [SerializeField] private Transform _respawnPoint;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private AudioSource _backgroundAudio;
    [SerializeField] private AudioClip _gameOverSound;

    private Player _deadPlayer;
    private bool _isDead;

    private void Start()
    {
        _deathScreen.SetActive(false);
    }

    private void Update()
    {
        if (_isDead == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RespawnPlayer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _deadPlayer = player;
            StopGame();  
        }
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        _isDead = true;
        _deathScreen.SetActive(true);
        _backgroundAudio.Stop();
        _backgroundAudio.PlayOneShot(_gameOverSound);
    }

    private void RespawnPlayer()
    {
        _deadPlayer.transform.position = _respawnPoint.position;
        Time.timeScale = 1;
        _isDead = false;
        _deathScreen.SetActive(false);
        _backgroundAudio.Play();
        _verticalMovement.ResetVerticalMovement();
    }
}