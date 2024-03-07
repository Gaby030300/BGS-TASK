using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    public static bool EPressed;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _buttonAction;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _buttonAction = _playerInput.actions["OpenPopUp"];
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
        EPressed = _buttonAction.IsPressed();
    }
}
