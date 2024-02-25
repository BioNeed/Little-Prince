using Assets.Scripts.Audio;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private BellSounds _bellSounds;

    public void RingBell()
    {
        _bellSounds.PlayBellRinging();
    }
}
