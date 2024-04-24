using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _fireRate = 1f;

    private List<IHealth> _enemies = new List<IHealth>();

    private float _actualTime = 0;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        _actualTime += Time.deltaTime;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IHealth>(out IHealth enemie))
            _enemies.Add(enemie);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IHealth>(out IHealth enemie))
            _enemies.Remove(enemie);
    }

    private void DamageLogic()
    {
        if (_actualTime <= _fireRate)
            return;

        _actualTime = 0;

        if (_enemies.Count == 0)
            return;

        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].GetDamage(_damage);
        }
    }
}