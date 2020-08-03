using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TargetScript : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    [SerializeField] float _movementForceMultiplier;

    [SerializeField] TrackWaypoint _nextWaypoint;
    internal TrackWaypoint NextWaypoint { get => _nextWaypoint; set => SetNextWaypoint(value); }
    private void SetNextWaypoint(TrackWaypoint value)
    {
        _nextWaypoint = value;
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce((NextWaypoint.transform.position - transform.position) * _movementForceMultiplier);
    }

    internal void Initialise(Vector3 startingPosition, TrackWaypoint nextWaypoint)
    {
        transform.position = startingPosition;
        NextWaypoint = nextWaypoint;
    }
}
