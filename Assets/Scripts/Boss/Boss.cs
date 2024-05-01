using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private int _playerDistance = 10;
    [SerializeField] private int _totemDistance = 5;
    [SerializeField] private float _speed = 1;

    [Header("Line Patern Parameters")]
    [SerializeField] private float _lineSpeed = 1;

    private int _index = 1;

    private List<Movement> _movList = new();

    private Vector3 _playerPositionStatic;

    private void OnEnable()
    {
        _player.actualPosition += HandleActualStopPosition;
        _player.onMovement += HandleOnPlayerMovement;
    }

    private void OnDisable()
    {
        _player.actualPosition -= HandleActualStopPosition;
        _player.onMovement -= HandleOnPlayerMovement;
    }

    private void Awake()
    {
        _movList.Add(new SearchMovement());
        _movList.Add(new CircleMovement());
        _playerPositionStatic = _player.transform.position;
    }

    private void Update()
    {
        if (_index == 0)
        {
            Movement(_movList[_index].GetDirection(_player.transform.position,transform.position));
        }
        else
        {
            Movement(_movList[_index].GetDirection(_playerPositionStatic, transform.position));
        }
    }

    private void HandleActualStopPosition(Vector3 position)
    {
        _playerPositionStatic = position;
        _index = 1;
    }

    private void Movement(Vector3 dir)
    {
        transform.Translate(dir * _speed * Time.deltaTime);
    }

    private void HandleOnPlayerMovement()
    {
        _index = 0;
    }
}