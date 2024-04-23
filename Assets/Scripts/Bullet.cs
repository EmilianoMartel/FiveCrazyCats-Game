using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHealth
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _lifeTime = 5f;

    private Vector3 _direction;
    private bool _isActive = true;

    private void Update()
    {
        transform.position += _direction * Time.deltaTime * _speed;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        _direction.z = 0;
    }

    private void HandleDamage(int damage)
    {
    }

    private void DieLogic()
    {
    }

    public void SuscribeDieEvent(Action action)
    { 

    }

    public void UnsuscribeDieEvent(Action action)
    {
    }
}
