using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TargetScript : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    [SerializeField] float _movementSpeed;

    [SerializeField] int _nextWaypointIndex;
    [SerializeField] TrackWaypoint NextWaypoint => TrackManager.Instance._trackWaypointList[_nextWaypointIndex];

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        TrackManager.TargetAddedAction?.Invoke(this);
    }
    private void OnDisable()
    {
        TrackManager.TargetRemovedAction?.Invoke(this);
    }

    float _distanceFromNextWaypoint;
    // Update is called once per frame
    void Update()
    {
        _distanceFromNextWaypoint = Vector2.Distance(transform.position, NextWaypoint.transform.position);

        if (_distanceFromNextWaypoint < 0.1f)
        {
            ReachedNextWaypoint();
        }
    }

    private void ReachedNextWaypoint()
    {
        _nextWaypointIndex = (_nextWaypointIndex + 1) % TrackManager.Instance._trackWaypointList.Count;
    }

    private void FixedUpdate()
    {
        var newPosition = Vector2.MoveTowards(transform.position, NextWaypoint.transform.position, _movementSpeed);
        _rigidbody.MovePosition(newPosition);
    }

    internal void Initialise(Vector3 startingPosition, int nextWaypointIndex)
    {
        transform.position = startingPosition;
        _nextWaypointIndex = nextWaypointIndex;
    }
}
