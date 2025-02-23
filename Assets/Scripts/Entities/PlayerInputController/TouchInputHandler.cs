using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputHandler : MonoBehaviour, IDragHandler
{
    private Vector2 _lastTouchPosition;
    public event System.Action<float> Draging;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position != _lastTouchPosition)
        {
            float offset;
            var nonNormalizedOffset = eventData.position.normalized.x - _lastTouchPosition.normalized.x;

            if (nonNormalizedOffset > 0) offset = 1;
            else if (nonNormalizedOffset < 0) offset = -1;
            else offset = 0;
            _lastTouchPosition = eventData.position;
            Draging?.Invoke(offset);
        }
    }
}
