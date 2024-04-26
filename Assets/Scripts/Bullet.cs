using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHealth, IHazard
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private int _damage = 1;

    private Vector3 _direction;

    private Action<Bullet> onDead = delegate { };

    private void Update()
    {
        transform.position += _direction * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealth hp))
            hp.GetDamage(DoDamage());
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        _direction.z = 0;
    }

    private void HandleDamage(int damage)
    {
        DieLogic();
    }

    private int DoDamage() 
    {
        return _damage;
    }

    private void DieLogic()
    {
        onDead?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void ActivateBullet()
    {
        gameObject.SetActive(true);
        StartCoroutine(WaitingForDisable());
    }

    public void SuscribeDieEvent(Action<Bullet> action)
    {
        onDead += action;
    }

    public void UnsuscribeDieEvent(Action<Bullet> action)
    {
        onDead -= action;
    }

    private IEnumerator WaitingForDisable()
    {
        yield return new WaitForSeconds(_lifeTime);
        DieLogic();
    }
}