using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class ShapesBehaviour : MonoBehaviour
{
    [Header("Cube")]
    [SerializeField] private Transform _cube;
    [SerializeField] private float _cubeSpeedRotation = 3f;
    [SerializeField] private LoopType _cubeLoopType;

    [Header("Sphere")]
    [SerializeField] private Transform _sphere;
    [SerializeField] private float _sphereSpeedTransition = 5f;
    [SerializeField] private Vector3 _sphereTargetPosition = new Vector3(0, 10, 0);
    [SerializeField] private LoopType _sphereLoopType;

    [Header("Capsule")]
    [SerializeField] private Transform _capsule;
    [SerializeField] private float _capsuleScaleDuration = 5f;
    [SerializeField] private Vector3 _cubeRotationAngle = new Vector3(360, 360, 360);
    [SerializeField] private Vector3 _capsuleScale = new Vector3(2, 2, 2);
    [SerializeField] private LoopType _capsuleLoopType;

    [Header("Cube2(move + rotate +scale)")]
    [SerializeField] private Transform _cube2;
    [SerializeField] private float _cube2RotateDuration = 3f;
    [SerializeField] private float _cube2SpeedTransition = 5f;
    [SerializeField] private float _cube2ScaleDuration = 5f;
    [SerializeField] private Vector3 _cube2TargetPosition = new Vector3(0, 10, 0);
    [SerializeField] private Vector3 _cube2TargetRotation = new Vector3(360, 360, 360);
    [SerializeField] private Vector3 _cube2TargetScale = new Vector3(2, 2, 2);
    [SerializeField] private LoopType _cube2LoopType;

    [Header("Cylinder")]
    [SerializeField] private Renderer _cylinderRenderer;
    [SerializeField] private Color _targetColor = Color.red;
    [SerializeField] private float _cylinderChangeColorDuration = 2f;
    [SerializeField] private LoopType _cylinderLoopType;

    [Header("Текст")]
    [SerializeField] private Text _text;
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private LoopType _textLoopType;

    [Header("General")]
    [SerializeField] private int _repeatsCount = -1;

    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(200, 10);
    }

    private void Start()
    {
        MoveObject();
        RotateObject();
        ScaleObject();
        MoveRotateScaleObject();
        ChangeColor();
        ChangeText();
    }

    private void RotateObject()
    {
        _cube.transform.DORotate(_cubeRotationAngle, _cubeSpeedRotation, RotateMode.FastBeyond360).SetLoops(_repeatsCount, _cubeLoopType);
    }

    private void MoveObject()
    {
        _sphere.transform.DOMove(_sphereTargetPosition, _sphereSpeedTransition).SetLoops(_repeatsCount, _sphereLoopType);
    }

    private void ScaleObject()
    {
        _capsule.transform.DOScale(_capsuleScale, _capsuleScaleDuration).SetLoops(_repeatsCount, _capsuleLoopType);
    }

    private void MoveRotateScaleObject()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .Join(_cube2.DOMove(_cube2TargetPosition, _cube2SpeedTransition))
            .Join(_cube2.DORotate(_cube2TargetRotation, _cube2RotateDuration))
            .Join(_cube2.DOScale(_cube2TargetScale, _cube2ScaleDuration));

        sequence.SetLoops(_repeatsCount, _cube2LoopType);
    }

    private void ChangeColor()
    {
        _cylinderRenderer.material.DOColor(_targetColor, _cylinderChangeColorDuration).SetLoops(_repeatsCount, _cylinderLoopType);
    }

     private void ChangeText()
    {
        _text.DOText("Измененный текст", _duration).SetLoops(_repeatsCount, _textLoopType);
        _text1.DOText(" Дополнительный текст", _duration).SetRelative().SetLoops(_repeatsCount, _textLoopType);
        _text2.DOText("Взломанный текст", _duration, true, ScrambleMode.All).SetLoops(_repeatsCount, _textLoopType);
    }
}