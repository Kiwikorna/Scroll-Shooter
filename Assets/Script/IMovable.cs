using UnityEngine;

public interface IMovable 
{
    public float MoveSpeed { get;}
    public Vector2 Direction { get;}
    public Vector2 NewPosition { get;}
    public bool IsMoving { get; }
    
    public void Move();
    public void StopMoving();
}
