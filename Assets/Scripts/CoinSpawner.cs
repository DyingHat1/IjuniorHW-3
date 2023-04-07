using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinTaker _coin;

    private Transform[] _spawnPoints;
    private int _currentPointIndex;
    private int _previousPointIndex;
    private int _spawnPointsCount;

    public void SpawnCoin()
    {
        while (_currentPointIndex == _previousPointIndex)
        {
            _currentPointIndex = Random.Range(0, _spawnPointsCount);
        }

        var newCoin = Instantiate(_coin, _spawnPoints[_currentPointIndex]);
        newCoin.Init(this);
        _previousPointIndex = _currentPointIndex;
    }

    private void Start()
    {
        _currentPointIndex = -1;
        _previousPointIndex = -1;
        _spawnPointsCount = transform.childCount;
        _spawnPoints = new Transform[_spawnPointsCount];

        for (int i = 0; i < _spawnPointsCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        SpawnCoin();
    }
}
