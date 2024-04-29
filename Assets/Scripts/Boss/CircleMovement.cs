using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float _rotationRadius = 2f, _angularSpeed = 2f;

    private float posX, posY, angle = 0f;

    public Transform player { get { return _player; } set { _player = value; } }

    private void Update()
    {
        posX = (transform.position.x -_player.position.x) + Mathf.Cos(angle) * _rotationRadius;
        posY = (transform.position.y - _player.position.y) + Mathf.Sin(angle) * _rotationRadius;
        
        Vector3 direction = _player.position - new Vector3(posX, posY, 0) ;

        transform.Translate(direction * Time.deltaTime);
        angle = angle + Time.deltaTime * _angularSpeed;

        if (angle >= 360f)
            angle = 0f;
    }
}