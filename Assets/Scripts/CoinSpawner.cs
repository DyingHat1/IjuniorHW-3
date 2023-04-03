using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinTaker _coin;

    private const string CloneString = "(Clone)";

    private Transform[] _spawnPoints;
    private int _currentPointIndex;
    private int _previousPointIndex;
    private int _spawnPointsCount;

    private void Start()
    {
        _currentPointIndex = -1;
        _previousPointIndex = -1;
        _spawnPointsCount = transform.childCount;
        _spawnPoints = new Transform[_spawnPointsCount];
        
        for(int i = 0; i < _spawnPointsCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        if (GameObject.Find(_coin.gameObject.name + CloneString) == null)
        {
            StartCoroutine(SpawnCoin());
        }
    }

    private IEnumerator SpawnCoin()
    {
        StopAllCoroutines();

        while (_currentPointIndex == _previousPointIndex)
        {
            _currentPointIndex = Random.Range(0, _spawnPointsCount);
        }

        Instantiate(_coin, _spawnPoints[_currentPointIndex]);
        _previousPointIndex = _currentPointIndex;

        yield return null;
    }
}
