using System.Collections;
using UnityEngine;

public class RotaterAround : MonoBehaviour 
{
    public float _rotationSpeed = 200f; // Скорость вращения
    private bool _isRotating = false; // Флаг вращения

    public void StartRotate()
    {
        if (!_isRotating) StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        _isRotating = true;
        float totalRotation = 0f;
        float rotationAmount = 360f;

        while (totalRotation < rotationAmount)
        {
            float rotationStep = _rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationStep, 0);
            totalRotation += rotationStep;
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0, 0, 0);
        _isRotating = false; 
    }
}
