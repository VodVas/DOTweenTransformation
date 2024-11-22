using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Transform _capsule;
    [SerializeField] private float _duration = 5f;
    [SerializeField] private Vector3 _targetScale = new Vector3(2, 2, 2);
    [SerializeField] private LoopType _loopType;
    [SerializeField] private int _repeatsCount = -1;

    private void Start()
    {
        StartEffect(_capsule, _targetScale, _duration, _loopType, _repeatsCount);
    }

    public Tween StartEffect(Transform transform, Vector3 targetScale, float duration, LoopType loopType, int repeatsCount = -1, bool applyLoops = true)
    {
        Tween tween = transform.DOScale(targetScale, duration);

        if (applyLoops)
        {
            tween.SetLoops(repeatsCount, loopType);
        }

        return tween;
    }
}