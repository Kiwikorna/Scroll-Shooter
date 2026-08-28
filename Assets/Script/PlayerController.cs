using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private  float moveSpeed = 5f;
    
     private PlayerMove _playerMove;

     private void Awake()
     {
         _playerMove = new PlayerMove();
         _playerMove.InitializedMovement(moveSpeed);
         _playerMove.SubmitMove();
     }

     public void Update()
    {
        if(_playerMove.Direction != Vector2.zero)
            transform.Translate(_playerMove.NewPosition * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _playerMove.DestroyObject();
    }
}
