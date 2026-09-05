using System;
using System.Collections;
using AttackComponent;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private  float moveSpeed = 5f;
    [SerializeField] private PlayerAttackWithBullet attackWithBulletComponent;
    
     private PlayerMove _playerMove;
     private InputAction _attackInput;
     private Coroutine _bulletSpawnCoroutine;
     private void Awake()
     {
         _playerMove = new PlayerMove();
         _playerMove.InitializedMovement(moveSpeed);
         _playerMove.SubmitMove();
         _attackInput = InputSystem.actions.FindAction("Attack");
         
     }

     public IEnumerator BulletSpawner()
     {
          attackWithBulletComponent.Attack();
         yield return new WaitForSeconds(.3f);
         _bulletSpawnCoroutine = null;
     }

     public void Update()
    {
        if (_attackInput.IsPressed() && _bulletSpawnCoroutine == null)
        {
            _bulletSpawnCoroutine = StartCoroutine(BulletSpawner());
        }
        if(_playerMove.Direction != Vector2.zero)
            transform.Translate(_playerMove.NewPosition * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _playerMove.UnSubmitMove();
    }
}
