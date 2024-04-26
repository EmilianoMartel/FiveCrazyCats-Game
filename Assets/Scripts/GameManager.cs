using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Totem> _totemList = new();

    private int _totalTotemsDie = 0;

    private void HandleTotemDie()
    {
        _totalTotemsDie++;
        if(_totalTotemsDie >= _totemList.Count)
        {
            //WIN
        }
    }
}