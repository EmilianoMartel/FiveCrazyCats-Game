using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private ShootLogic _shoot;
    [SerializeField] private Bullet _bulletPrefab;

    private List<Bullet> _activeList = new();
    private List<Bullet> _objectList = new();

    private Transform _pointShoot;

    private void OnEnable()
    {
        _shoot.onPointShoot += HandleSetShootPoint;
        _shoot.onShoot += HandleShoot;
    }

    private void OnDisable()
    {
        _shoot.onPointShoot -= HandleSetShootPoint;
        _shoot.onShoot -= HandleShoot;
    }

    private void HandleSetShootPoint(Transform pointShoot)
    {
        _pointShoot = pointShoot;
    }

    private void HandleShoot(Vector3 direction)
    {
        Bullet temp = SelectBullet();
        temp.transform.position = _pointShoot.position;
        temp.SetDirection(direction);

        if (_objectList.Contains(temp))
            _objectList.Remove(temp);

        _activeList.Add(temp);
        temp.ActivateBullet();
    }

    private Bullet SelectBullet()
    {
        if (_objectList.Count == 0)
        {
            Bullet temp = Instantiate(_bulletPrefab, _pointShoot.position, Quaternion.identity);
            temp.SuscribeDieEvent(HandleDesactiveBullet);
            return temp;
        }

        return _objectList[0];
    }

    private void HandleDesactiveBullet(Bullet bullet)
    {
        if (_activeList.Contains(bullet))
        {
            _activeList.Remove(bullet);
            _objectList.Add(bullet);
        }
    }
}