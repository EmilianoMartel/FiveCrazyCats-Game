using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [Header("Parameters")]
    [SerializeField] private float _speedImpulse = 10f;

    private float _actualSpeed = 0;

    private Vector3 _targetPosition;
    private Vector3 _worldPosition;
    private Vector3 _movementTarget;

    private Camera _camera;
    private Mouse _mouse;

    private void OnEnable()
    {
        _reader.onMove += HandleMovement;
    }

    private void OnDisable()
    {
        _reader.onMove -= HandleMovement;
    }

    private void Awake()
    {
        _camera = Camera.main;
        _mouse = Mouse.current;
    }

    private void Update()
    {
        GetTargetPosition();
        MovementLogic();
    }

    private void GetTargetPosition()
    {
        _targetPosition = _mouse.position.ReadValue();
        _targetPosition.z = _camera.nearClipPlane;
        _worldPosition = _camera.ScreenToWorldPoint(_targetPosition);

        RotateAimTarget(_worldPosition);
    }

    private void HandleMovement()
    {
        _movementTarget = _worldPosition - transform.position;
        _movementTarget = _movementTarget.normalized;
        _movementTarget.z = 0;
        _actualSpeed = _speedImpulse;
    }

    private void MovementLogic()
    {
        if (_actualSpeed <= 0)
            return;
                
        transform.position += _movementTarget * Time.deltaTime * _speedImpulse;
        _actualSpeed -= Time.deltaTime;
    }

    private void RotateAimTarget(Vector3 worldpos)
    {
        Vector3 rotation = (worldpos - transform.position).normalized;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}