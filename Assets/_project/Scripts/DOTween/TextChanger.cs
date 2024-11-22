using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private float _duration = 3f;
    [SerializeField] private LoopType _textLoopType;
    [SerializeField] private int _repeatsCount = -1;

    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly).SetCapacity(200, 10);
    }

    private void Start()
    {
        Unite();
    }

    private void Unite()
    {
        Replace();
        Expand();
        Hack();
    }

    private void Replace()
    {
        _text.DOText("Измененный текст", _duration).SetLoops(_repeatsCount, _textLoopType);
    }

    private void Expand()
    {
        _text1.DOText(" Дополнительный текст", _duration).SetRelative().SetLoops(_repeatsCount, _textLoopType);
    }

    private void Hack()
    {
        _text2.DOText("Взломанный текст", _duration, true, ScrambleMode.All).SetLoops(_repeatsCount, _textLoopType);
    }
}
