using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : IMovable
{
    public float MoveSpeed { get; private set; }
    public Vector2 Direction { get; private set; }
    public Vector2 NewPosition { get; private set; }
    public bool IsMoving { get; private set; }
    
    private  InputAction _moveInput;

    public void InitializedMovement(in float moveSpeed)
    {
        InitializeMoveSpeed(moveSpeed);
        InitializeMoveProperties();
    }
    private void InitializeMoveSpeed(in float moveSpeed) => MoveSpeed = moveSpeed;
    private void InitializeMoveProperties()
    {
        IsMoving = false;
        _moveInput = InputSystem.actions.FindAction("Move");
    }

    public  void SubmitMove()
    {
        _moveInput.performed += OnMoved;
        _moveInput.canceled += OnMoved;
    }
    public void UnSubmitMove()
    {
        _moveInput.performed -= OnMoved;
        _moveInput.canceled -= OnMoved;
    }
    private void OnMoved(InputAction.CallbackContext obj)
    {
        
        Direction = obj.ReadValue<Vector2>();
        Move();
    }
    public void Move()
    {
        NewPosition = Direction * MoveSpeed;
    }

    public void StopMoving()
    {
        Direction = Vector2.zero;
    }

    
}
