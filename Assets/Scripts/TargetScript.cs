using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
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
}
