using System;
using AttackComponent;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private  float moveSpeed = 5f;
    [FormerlySerializedAs("attackComponent")] [SerializeField] private PlayerAttackWithBullet attackWithBulletComponent;
    
     private PlayerMove _playerMove;

     private InputAction _attackInput;
     private void Awake()
     {
         _playerMove = new PlayerMove();
         _playerMove.InitializedMovement(moveSpeed);
         _playerMove.SubmitMove();
         _attackInput = InputSystem.actions.FindAction("Attack");
         _attackInput.performed += AttackInputOnPerformed;
     }

     private void AttackInputOnPerformed(InputAction.CallbackContext obj)
     {
         attackWithBulletComponent.Attack();
     }

     public void Update()
    {
        if(_playerMove.Direction != Vector2.zero)
            transform.Translate(_playerMove.NewPosition * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _playerMove.UnSubmitMove();
        _attackInput.performed -= AttackInputOnPerformed;
    }
}
