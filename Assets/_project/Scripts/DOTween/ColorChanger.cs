using DG.Tweening;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _targetColor = Color.red;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private int _repeatsCount = -1;

    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(200, 10);
    }

    private void Start()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        _renderer.material.DOColor(_targetColor, _duration).SetLoops(_repeatsCount, _loopType);
    }
}