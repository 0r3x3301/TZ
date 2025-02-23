using UnityEngine;
public class SideMovingHandler
{
    [SerializeField] private IHaveTransform _movingEntity;

    public SideMovingHandler(IHaveTransform movingEntity)
    {
        _movingEntity = movingEntity;
    }

    public void Move(Vector3 direction, float speed)
    {
        _movingEntity.Transform.Translate(direction * speed);
    }
}

