using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _cube;
    [SerializeField] private float _rotationSpeed = 3f;
    [SerializeField] private Vector3 _rotationAngle = new Vector3(360, 360, 360);
    [SerializeField] private LoopType _loopType;
    [SerializeField] private int _repeatsCount = -1;

    private void Start()
    {
        StartEffect(_cube, _rotationAngle, _rotationSpeed, _loopType, _repeatsCount);
    }

    public Tween StartEffect(Transform transform, Vector3 targetRotation, float duration, LoopType loopType, int repeatsCount = -1, bool applyLoops = true)
    {
        Tween tween = transform.DORotate(targetRotation, duration, RotateMode.FastBeyond360);

        if (applyLoops)
        {
            tween.SetLoops(repeatsCount, loopType);
        }

        return tween;
    }
}