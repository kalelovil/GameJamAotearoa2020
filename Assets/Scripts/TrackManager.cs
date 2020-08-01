using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] bool _hasChanged;

    [SerializeField] List<TrackWaypoint> _trackWaypointList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
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

        _hasChanged = false;
    }

    private void LateUpdate()
    {
    }
}
