using System;
using UnityEngine;

public class cameramanager : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 _offset;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    
    private void Awake()
    {
        _offset = transform.position - target.position;
    }
 
    private void LateUpdate()
    {
        var targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
