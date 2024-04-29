using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private SearchMovement _line;
    [SerializeField] private CircleMovement _patron;

    private void OnEnable()
    {
        _player.actualPosition += HandleActualStopPosition;
    }

    private void OnDisable()
    {
        _player.actualPosition -= HandleActualStopPosition;
    }

    private void Update()
    {
        if (_player.isMoving)
            _patron.enabled = false;
        else
            _line.enabled = true;
    }

    private void HandleActualStopPosition(Vector3 position)
    {
        _patron.enabled = true;
        _line.enabled = false;
        _patron.player.position = position;
    }

}