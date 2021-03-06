﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackWaypoint : MonoBehaviour
{
    [SerializeField] internal TextMeshPro _numText;
    [SerializeField] internal LineRenderer _lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        TrackManager.WaypointAddedAction?.Invoke(this);
    }
    private void OnDisable()
    {
        TrackManager.WaypointRemovedAction?.Invoke(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
