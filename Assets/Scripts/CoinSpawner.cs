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
    private bool _isCoinOnScene;

    private void Start()
    {
        _currentPointIndex = -1;
        _previousPointIndex = -1;
        _spawnPointsCount = transform.childCount;
        _spawnPoints = new Transform[_spawnPointsCount];
        _isCoinOnScene = false;


        for (int i = 0; i < _spawnPointsCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        _isCoinOnScene = CheckCoins();

        if (_isCoinOnScene == false)
            SpawnCoin();
    }

    private bool CheckCoins()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            if (spawnPoint.childCount > 0)
                return true;
        }

        return false;
    }

    private void SpawnCoin()
    {
        while (_currentPointIndex == _previousPointIndex)
        {
            _currentPointIndex = Random.Range(0, _spawnPointsCount);
        }

        Instantiate(_coin, _spawnPoints[_currentPointIndex]);
        _previousPointIndex = _currentPointIndex;
    }
}
