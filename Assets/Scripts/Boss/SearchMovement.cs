using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMovement : Movement
{
    private float _speed = 1;

    private Vector3 _movement;

    public override Vector3 GetDirection(Vector3 target,Vector3 self)
    {
        _movement = target - self;
        _movement.Normalize();
        return _movement;
    }
}