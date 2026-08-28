using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour,IMovable
{
    [SerializeField] private  float moveSpeed = 5f;
    
    [Header("Property")]
    public float MoveSpeed { get; private set; }
    public Vector2 Direction { get; private set; }
    public Vector2 NewPosition { get; private set; }
    public bool IsMoving { get; private set; }
    
    private  InputAction _moveInput;

    private void Awake()
    {
        InitializeMoveProperty();
        SubmitMove();
    }

    private void InitializeMoveProperty()
    {
        MoveSpeed = moveSpeed;
        IsMoving = false;
        _moveInput = InputSystem.actions.FindAction("Move");
    }

    private  void SubmitMove()
    {
        _moveInput.performed += OnMoved;
        _moveInput.canceled += OnMoved;
    }
    private void UnSubmitMove()
    {
        _moveInput.performed -= OnMoved;
        _moveInput.canceled -= OnMoved;
    }
    private void OnMoved(InputAction.CallbackContext obj)
    {
        Direction = obj.ReadValue<Vector2>();
        Move();
    }
    private void OnStoppedMoved(InputAction.CallbackContext obj)
    {
        Direction = obj.ReadValue<Vector2>();
        Move();
    }

    public void Update()
    {
        if(Direction != Vector2.zero)
            transform.Translate(NewPosition * Time.deltaTime);
    }

    public void Move()
    {
        NewPosition = Direction * MoveSpeed;
    }

    public void StopMoving()
    {
        throw new System.NotImplementedException();
    }
}
