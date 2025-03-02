using System;
using System.Collections;
using UnityEngine;
[SelectionBase]
public class Player : MonoBehaviour, IMoving, IRotating, IHaveRating
{
    #region SerializeFields
    [SerializeField] private Transform _transform;
    [SerializeField] private float _movingSpeed = 2f;
    [SerializeField] private float _rotatingSpeed = 2f;
    [SerializeField] private int _startRating = 51;
    [SerializeField] private PlayerAnimationController _animationController;
    [SerializeField] private AudioClip _moveAudio;
    #endregion

    #region Flags
    private bool _canMoving = false;
    private bool _isMooving = false;
    private bool _timerStarted = false;
    #endregion
    
    #region Handlers
    private IRotatingHandler _rotatingHandler;
    private IMovingHandler _movingHandler;
    #endregion

    private Quaternion _needRotation = Quaternion.Euler(Vector3.zero);
    private int _currentRating = 0;

    #region Events
    public event Action<int> RatingIncreased;
    public event Action<int> RatingDecreased;
    #endregion

    #region Consts
    private readonly Quaternion _zeroRotation = Quaternion.Euler(Vector3.zero);
    #endregion

    #region Properties
    public Transform Transform => _transform;
    public float Speed => _movingSpeed;
    public float RotatingSpeed => _rotatingSpeed;
    public bool CanMoving => _canMoving;
    public int Rating => _currentRating;
    public bool IsMoving => _isMooving;
    public bool Stopped { get; private set; } = false;
    #endregion

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _transform = GetComponent<Transform>();

        _movingHandler = new ForwardMovingHandler(this);
        _rotatingHandler = new RotatingHaldler(this);
        _currentRating = _startRating;
    }

    private void Update()
    {
        if (CanMoving)
        {
            Move();
        }

        if (_needRotation != _zeroRotation)
        {
            RotateTo(_needRotation);
        }
    }

    public void StartMoving()
    {
        _isMooving = true;
        _canMoving = true;
        _animationController.PlayWalking();
        IncreaseRating(0);
    }

    public void Move()
    {
        if (_canMoving)
        {
            _movingHandler.Move(_transform.InverseTransformDirection(_transform.forward));
            if (!_timerStarted) StartCoroutine(PlayWalkSound(1f));
        }
    }

    private IEnumerator PlayWalkSound(float seconds)
    {
        _timerStarted = true;
        yield return new WaitForSeconds(seconds);
        SoundManager.GetInstance().Play(_moveAudio, UnityEngine.Random.Range(0.5f, 1f));
        _timerStarted = false;
    }

    private void RotateTo(Quaternion rotation)
    {
        _rotatingHandler.RotateTo(rotation);
    }

    public void StartRotateFor(float angle)
    {
        var newRotation = _transform.rotation.eulerAngles;
        newRotation.y += angle;
        _needRotation = Quaternion.Euler(newRotation);
    }

    public void IncreaseRating(int value)
    {
        _currentRating += value;
        RatingIncreased?.Invoke(value);
    }

    public void DecreaseRating(int value)
    {
        _currentRating -= value;
        RatingDecreased?.Invoke(value);
    }

    public void OnWin()
    {
        SoundManager.GetInstance().StopPlay();
        _animationController.PlayWin();
        _isMooving = false;
        _canMoving = false;
        Stopped = true;
    }

    public void OnLose()
    {
        SoundManager.GetInstance().StopPlay();
        _animationController.PlayLose();
        _canMoving = false;
        _isMooving = false;
        Stopped = true;
    }
}


