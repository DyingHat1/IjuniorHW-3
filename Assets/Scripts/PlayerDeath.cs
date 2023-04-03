using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            transform.position = _startPoint.position;
        }
    }
}
