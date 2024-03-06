using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rb;

    private Animator _animator;

    private Vector2 _movement;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        _rb.velocity = _movement * _moveSpeed;
        
        _animator.SetFloat(Horizontal, _movement.x);
        _animator.SetFloat(Vertical, _movement.y);
    }
}
