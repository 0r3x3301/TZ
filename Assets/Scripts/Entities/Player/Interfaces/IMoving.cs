using UnityEngine;

public interface IMoving : IHaveTransform
{
    public float Speed { get; }
    public bool CanMoving { get; }
    public void Move();
}
