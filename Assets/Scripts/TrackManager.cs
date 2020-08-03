using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] bool _hasChanged;

    [SerializeField] internal List<TrackWaypoint> _trackWaypointList;

    [SerializeField] List<TargetScript> _targetList;

    public static Action<TrackWaypoint> WaypointAddedAction;
    public static Action<TrackWaypoint> WaypointRemovedAction;

    public static Action<TargetScript> TargetAddedAction;
    public static Action<TargetScript> TargetRemovedAction;

    public static TrackManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        WaypointAddedAction += WaypointAdded;
        WaypointRemovedAction += WaypointRemoved;
        TargetAddedAction += TargetAdded;
        TargetRemovedAction += TargetRemoved;
    }
    private void OnDisable()
    {
        WaypointAddedAction -= WaypointAdded;
        WaypointRemovedAction -= WaypointRemoved;
        TargetAddedAction -= TargetAdded;
        TargetRemovedAction -= TargetRemoved;
    }

    void WaypointAdded(TrackWaypoint waypoint)
    {
        //_trackWaypointList.Add(waypoint);
    }
    void WaypointRemoved(TrackWaypoint waypoint)
    {
        //_trackWaypointList.Remove(waypoint);
    }

    void TargetAdded(TargetScript target)
    {
        _targetList.Add(target);

        if (_trackWaypointList.Count > 0)
        {
            int randomWaypointIndex = UnityEngine.Random.Range(0, _trackWaypointList.Count);
            var randomWaypoint = _trackWaypointList[randomWaypointIndex];
            int nextWaypointIndex = (randomWaypointIndex + 1) % _trackWaypointList.Count;
            var nextWaypoint = _trackWaypointList[nextWaypointIndex];

            target.Initialise(randomWaypoint.transform.position, nextWaypointIndex);
        }
    }
    void TargetRemoved(TargetScript target)
    {
        _targetList.Remove(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        SetupWaypoints();

        //SetupTargets();

        _hasChanged = false;
    }

    private void SetupWaypoints()
    {
        _trackWaypointList = transform.GetComponentsInChildren<TrackWaypoint>().ToList();
        TrackWaypoint curWaypoint, nextWaypoint;
        for (int i = 0; i < _trackWaypointList.Count; i++)
        {
            curWaypoint = _trackWaypointList[i];
            nextWaypoint = _trackWaypointList[(i + 1) % _trackWaypointList.Count];

            curWaypoint._numText.text = $"{i + 1}";
            curWaypoint._lineRenderer.positionCount = 2;
            curWaypoint._lineRenderer.SetPosition(0, curWaypoint.transform.position);
            curWaypoint._lineRenderer.SetPosition(1, nextWaypoint.transform.position);
        }
    }

    private void LateUpdate()
    {
    }
}
