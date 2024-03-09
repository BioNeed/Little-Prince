using Assets.Scripts.Audio;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private BellPuzzle _bellPuzzle;
    [SerializeField] private int _bellNumber;
    [SerializeField] private BellSounds _bellSounds;

    public int BellNumber => _bellNumber;

    public void RingBell(bool initiatedByCollision)
    {
        _bellSounds.PlayBellRinging();

        if (initiatedByCollision)
        {
            _bellPuzzle.TrySolvePuzzle(_bellNumber);
        }
    }
}
