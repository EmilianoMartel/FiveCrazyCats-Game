using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Searcher : MonoBehaviour
{
    [SerializeField] private ITarget _iTarget;

    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Image _searchImage;
    [SerializeField] private float _treshold = 0.00001f;

    private Vector2 _targetPosition;
    private Vector2 _searcherPosition;

    private void Update()
    {
        SearchLogic();
    }

    private void SearchLogic()
    {
        float minX = _searchImage.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = _searchImage.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        _searcherPosition = Camera.main.WorldToScreenPoint(_targetTransform.position);

        if (Vector3.Dot((_targetTransform.position - transform.position), transform.forward) < 0)
        {
            if (_searcherPosition.x < Screen.width / 2)
                _targetPosition.x = maxX;
            else
                _targetPosition.x = minX;
        }

        _targetPosition.x = Mathf.Clamp(_searcherPosition.x, minX, maxX);
        _targetPosition.y = Mathf.Clamp(_searcherPosition.y, minY, maxY);

        _searchImage.transform.position = _targetPosition;
        EnableLookLogic();
    }

    private void EnableLookLogic()
    {
        if (_searcherPosition == _targetPosition)
        {
            _searchImage.gameObject.SetActive(false);
        }
        else
        {
            _searchImage.gameObject.SetActive(true);
        }
    }
}