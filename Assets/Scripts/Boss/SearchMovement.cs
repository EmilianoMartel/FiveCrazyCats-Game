using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1;

    private Vector3 _movement;

    private void Update()
    {
        _movement = _target.position - transform.position;
        _movement.Normalize();
        //transform.position += _movement * Time.deltaTime;
    }
}