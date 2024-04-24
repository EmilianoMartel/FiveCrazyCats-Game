using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootLogic : MonoBehaviour
{
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private float _timeBetweenShoot = 2f;

    private bool _isShooting = false;

    public event Action<Transform> onPointShoot = delegate { };
    public event Action<Vector3> onShoot = delegate { };

    private void Start()
    {
        onPointShoot?.Invoke(_pointShoot);
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_isShooting)
            return;

        StartCoroutine(ShootMomentLogic());
    }

    private IEnumerator ShootMomentLogic()
    {
        _isShooting = true;
        yield return new WaitForSeconds(_timeBetweenShoot);
        onShoot?.Invoke((_pointShoot.position - transform.position).normalized);
        _isShooting = false;
    }
}