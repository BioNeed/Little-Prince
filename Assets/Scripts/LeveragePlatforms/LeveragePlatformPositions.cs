using UnityEngine;

public class LeveragePlatformPositions : MonoBehaviour
{
    [SerializeField] private Transform _zeroLevelPosition;
    [SerializeField] private float _heightLevelOffset;

    public float GetLevelHeight(int level)
    {
        return _zeroLevelPosition.position.y + level * _heightLevelOffset;
    }
}
