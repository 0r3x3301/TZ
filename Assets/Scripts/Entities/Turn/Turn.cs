using UnityEngine;

public class Turn : MonoBehaviour, ITurn
{
    [SerializeField] private float _turnAngle;
    public float GetTurnAngle()
    {
        return _turnAngle;
    }

    private void OnTriggerEnter(Collider other)
    {
        IRotating rotatingEntity;
        if (other.TryGetComponent(out rotatingEntity))
        {
            rotatingEntity.StartRotateFor(_turnAngle);
            Destroy(gameObject);
        }
    }
}