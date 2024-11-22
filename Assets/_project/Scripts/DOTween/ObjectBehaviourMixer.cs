using DG.Tweening;
using UnityEngine;

public class ObjectBehaviourMixer : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private float _rotateDuration = 3f;
    [SerializeField] private float _transitionSpeed = 5f;
    [SerializeField] private float _scaleDuration = 5f;
    [SerializeField] private Vector3 _targetPosition = new Vector3(0, 10, 0);
    [SerializeField] private Vector3 _targetRotation = new Vector3(360, 360, 360);
    [SerializeField] private Vector3 _targetScale = new Vector3(2, 2, 2);
    [SerializeField] private LoopType _loopType;
    [SerializeField] private int _repeatsCount = -1;

    private Mover _mover;
    private Scaler _scaler;
    private Rotator _rotator;

    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(200, 10);

        _mover = GetComponent<Mover>();
        _scaler = GetComponent<Scaler>();
        _rotator = GetComponent<Rotator>();
    }

    private void Start()
    {
        StartEffect();
    }

    private void StartEffect()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .Join(_mover.StartEffect(_object, _targetPosition, _transitionSpeed, _loopType, _repeatsCount, false))
            .Join(_rotator.StartEffect(_object, _targetRotation, _rotateDuration, _loopType, _repeatsCount, false))
            .Join(_scaler.StartEffect(_object, _targetScale, _scaleDuration, _loopType, _repeatsCount, false));

        sequence.SetLoops(_repeatsCount, _loopType);
    }
}