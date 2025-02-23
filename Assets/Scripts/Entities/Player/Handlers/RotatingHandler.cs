using UnityEngine;

public class RotatingHaldler : IRotatingHandler
{
    private IRotating _rotatingEntity;

    public RotatingHaldler(IRotating rotatingEntity)
    {
        _rotatingEntity = rotatingEntity;
    }

    public void RotateTo(Quaternion rotation)
    {
        _rotatingEntity.Transform.rotation = Quaternion.RotateTowards(_rotatingEntity.Transform.rotation, rotation, _rotatingEntity.RotatingSpeed * Time.deltaTime);
    }
}