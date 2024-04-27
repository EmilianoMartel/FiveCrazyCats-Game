using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour, IHealth, IHazard, ITarget
{
    [SerializeField] private int _maxLifePoints = 100;
    [SerializeField] private int _damage = 1;
    private int _currentLifePoints;

    public Action<Totem> onDeath = delegate { };
    public Action<Transform> onSetTarget = delegate { };

    private void Awake()
    {
        _currentLifePoints = _maxLifePoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IHealth>(out IHealth hp))
            hp.GetDamage(DoDamage());
    }

    private void OnBecameVisible()
    {
        Debug.Log("SI");
    }

    public void GetDamage(int damage)
    {
        _currentLifePoints -= damage;

        Debug.Log($"{name} was recive {damage} point damage, life is {_currentLifePoints}");

        if (_currentLifePoints <= 0)
            DieLogic();
    }

    private int DoDamage()
    {
        return _damage;
    }

    private void DieLogic()
    {
        onDeath?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void SuscribeDieEvent(Action<Totem> action) { onDeath += action; }

    public void UnsuscribeDieEvent(Action<Totem> action) { onDeath -= action; }

    private void SetTarget()
    {
        onSetTarget?.Invoke(gameObject.transform);
    }

    private void DisabledTarget() { }
}