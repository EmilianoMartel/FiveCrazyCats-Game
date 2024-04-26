using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour, IHealth, IHazard
{
    [SerializeField] private int _maxLifePoints = 100;
    [SerializeField] private int _damage = 1;

    private int _currentLifePoints;

    public Action onDeath = delegate { };

    private void Awake()
    {
        _currentLifePoints = _maxLifePoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IHealth>(out IHealth hp))
            hp.GetDamage(DoDamage());
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

    private void DieLogic() { }

    public void SuscribeDieEvent(Action action) { }

    public void UnsuscribeDieEvent(Action action) { }
}