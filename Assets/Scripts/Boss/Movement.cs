using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    public virtual Vector3 GetDirection(Vector3 playerPosition,Vector3 selfPosition)
    {
        Vector3 direction = playerPosition - selfPosition;
        direction.Normalize();
        return direction;
    }
}