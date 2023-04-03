using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Animator _animator;

    private const string AllRunButtonsOffBool = "AllButtonsOff";
    private const string PlayerOnGroundBool = "PlayerOnGround";
    private const string PlayerFacingRightBool = "PlayerFacingRight";

    private float _jumpForce;
    private Rigidbody2D _rigidbody2D;
    private bool _playerIsStanding;
    private bool _playerHasJumped;
    private Vector2 _jumpVector;
    
    private void Start()
    {
        _playerIsStanding = true;
        _playerHasJumped = false;
        _animator.SetBool(PlayerFacingRightBool, true);
        _animator.SetBool(PlayerOnGroundBool, true);
        _animator.SetBool(AllRunButtonsOffBool, false);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpForce = Mathf.Sqrt(_jumpHeight * (-2) * (Physics2D.gravity.y * _rigidbody2D.gravityScale));
        _jumpVector = new Vector2(0, _jumpForce);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Direction.Right);
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {

                MovePlayer(Direction.Left);
            }
            else
            {
                _animator.SetBool(AllRunButtonsOffBool, true);
            }
        }

        if (Input.GetKey(KeyCode.W) && _playerIsStanding && _playerHasJumped == false)
        {
            _rigidbody2D.AddForce(_jumpVector, ForceMode2D.Impulse);
            _playerHasJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _playerIsStanding = true;
            _playerHasJumped = false;
            _animator.SetBool(PlayerOnGroundBool, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _playerIsStanding = false;
            _animator.SetBool(PlayerOnGroundBool, false);
        }
    }

    private void MovePlayer(Direction direction)
    {
        bool isPlayerFacingRight;

        if ((int)direction > 0)
            isPlayerFacingRight = true;
        else
            isPlayerFacingRight = false;

        _animator.SetBool(AllRunButtonsOffBool, false);
        transform.Translate((int)direction * _speed * Time.deltaTime, 0, 0);
        _animator.SetBool(PlayerFacingRightBool, isPlayerFacingRight);
    }

    enum Direction
    {
        Right = 1,
        Left = -1
    }
}
