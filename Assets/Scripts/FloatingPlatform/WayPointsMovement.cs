using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointsMovement : MonoBehaviour
{
    private List<WayPoint> _wayPoints = new List<WayPoint>();
    private int _nextWayPointIndex;
    private WayPoint _nextWayPoint;

    public WayPoint NextWayPoint => _nextWayPoint;

    private void Awake()
    {
        _wayPoints = GetComponentsInChildren<WayPoint>().ToList();
        InitFirstWayPoint();
    }

    private void InitFirstWayPoint()
    {
        _nextWayPointIndex = 0;
        _nextWayPoint = _wayPoints[0];
    }

    public WayPoint GetStartWayPoint()
    {
        return _wayPoints[0];
    }

    public WayPoint FindNextWayPoint()
    {
        _nextWayPointIndex++;

        if (_nextWayPointIndex == _wayPoints.Count)
        {
            _nextWayPointIndex = 0;
        }

        _nextWayPoint = _wayPoints[_nextWayPointIndex];

        return _nextWayPoint;
    }
}
