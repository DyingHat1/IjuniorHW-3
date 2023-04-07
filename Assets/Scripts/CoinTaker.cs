using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    public void Init(CoinSpawner coinSpawner)
    {
        _coinSpawner = coinSpawner;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _coinSpawner.SpawnCoin();
            Destroy(gameObject);
        }
    }
}
