using UnityEngine;

public interface IRotating : IHaveTransform
{
    public float RotatingSpeed { get; }
    public void StartRotateFor(float angle);
}

