using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private const string EnemyFacingRight = "EnemyFacingRight";
    private Transform[] _points;
    private int _currentPoint;
    private bool _isEnemyFacingRight;

    private void Start()
    {
        _points = new Transform[_path.childCount];
        _currentPoint = 0;
        _isEnemyFacingRight = false;

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        if (target.position.x < transform.position.x)
            _isEnemyFacingRight = false;
        else
            _isEnemyFacingRight = true;

        _animator.SetBool(EnemyFacingRight, _isEnemyFacingRight);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}