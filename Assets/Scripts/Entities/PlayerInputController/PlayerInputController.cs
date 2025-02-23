using UnityEngine;
public class PlayerInputController : MonoBehaviour 
{
    [SerializeField] private float _movingSpeed = 9f;
    [SerializeField] private TouchInputHandler _touchInputHandler;
    [SerializeField] private Player _player;

    private bool _canMoving = true;

    private SideMovingHandler _movingHandler;


    private void Start()
    {
        _movingHandler = new(_player);
    }

    private void MovePlayer(float inputOffset)
    {
        if (_canMoving && !_player.Stopped)
        {
            if (!_player.IsMoving)
            {
                UIManager.GetInstance().ShowInGameUI();
                UIManager.GetInstance().HideStartUI();
                _player.StartMoving();
            }
            var totalSpeed = _movingSpeed * inputOffset * Time.deltaTime;
            _movingHandler.Move(_player.Transform.InverseTransformDirection(_player.Transform.right), totalSpeed);
        }
    }
    private void OnEnable()
    {
        _touchInputHandler.Draging += MovePlayer;
    }

    private void OnDisable()
    {
        _touchInputHandler.Draging -= MovePlayer;
    }
}

