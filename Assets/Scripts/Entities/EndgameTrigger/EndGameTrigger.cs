using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player;
        if (other.TryGetComponent(out player))
        {
            GameManager.Instance.Win();
        }
    }
}
