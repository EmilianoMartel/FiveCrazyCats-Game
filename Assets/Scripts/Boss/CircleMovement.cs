using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CircleMovement : Movement
{
    private float _rotationRadius = 5f, _angularSpeed = 0.5f;

    private float posX, posY, angle = 0f;

    public override Vector3 GetDirection(Vector3 playerPosition, Vector3 selfPosition)
    {
        posX = (playerPosition.x) + Mathf.Cos(angle) * _rotationRadius;
        posY = (playerPosition.y) + Mathf.Sin(angle) * _rotationRadius;

        Vector3 direction = new Vector3(posX, posY, 0) - selfPosition;

        angle = angle + Time.deltaTime * _angularSpeed;

        if (angle >= 360f)
            angle = 0f;

        return direction;
    }
}