using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _sphere;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector3 _targetPosition = new Vector3(0, 10, 0);
    [SerializeField] private LoopType _loopType;
    [SerializeField] private int _repeatsCount = -1;

    private void Start()
    {
        StartEffect(_sphere, _targetPosition, _speed, _loopType, _repeatsCount);
    }

    public Tween StartEffect(Transform transform, Vector3 targetPosition, float speed, LoopType loopType, int repeatsCount = -1, bool applyLoops = true)
    {
        Tween tween = transform.DOMove(targetPosition, speed);

        if (applyLoops)
        {
            tween.SetLoops(repeatsCount, loopType);
        }

        return tween;
    }
}