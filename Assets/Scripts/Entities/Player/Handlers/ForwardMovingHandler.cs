using UnityEngine;
public class ForwardMovingHandler : IMovingHandler
{
    private IMoving _movingEntity;

    public ForwardMovingHandler(IMoving movingEntity)
    {
        _movingEntity = movingEntity;
    }

    public void Move(Vector3 direction)
    {
        _movingEntity.Transform.Translate(direction * _movingEntity.Speed * Time.deltaTime);
    }
}
