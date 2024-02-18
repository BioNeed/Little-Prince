using Assets.Scripts.LeveragePlatforms;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool _initialTurnedOn;
    [SerializeField] private LeveragePlatformMovement _firstPlatform;
    [SerializeField] private bool _firstPlatformGoesUpOnTurnedOn;
    [SerializeField] private LeveragePlatformMovement _secondPlatform;
    [SerializeField] private bool _secondPlatformGoesUpOnTurnedOn;
    [SerializeField] private Animator _leverAnimator;
    [SerializeField] private LeverSounds _leverSounds;
    
    private bool _turnedOn;

    private void Start()
    {
        _turnedOn = _initialTurnedOn;
        _leverAnimator.SetBool("IsOn", _turnedOn);
    }

    public void ToggleLever()
    {
        _turnedOn = !_turnedOn;
        var firstPlatformMoveUp = _turnedOn == _firstPlatformGoesUpOnTurnedOn;
        _firstPlatform.MovePlatform(firstPlatformMoveUp);

        var secondPlatformMoveUp = _turnedOn == _secondPlatformGoesUpOnTurnedOn;
        _secondPlatform.MovePlatform(secondPlatformMoveUp);
        _leverAnimator.SetBool("IsOn", _turnedOn);
        _leverSounds.PlayLeverToggling();
    }
}
