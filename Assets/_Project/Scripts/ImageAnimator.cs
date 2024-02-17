using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageAnimator : MonoBehaviour
{
    [SerializeField] private Image _testImage;


    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    { 
       Sequence sequence = DOTween.Sequence();

        sequence.Append(_testImage.rectTransform.DORotate(new Vector3(0.0f, 0.0f, Random.Range(-360, 360)), Random.Range(3, 5), RotateMode.LocalAxisAdd).
            SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));

        sequence.Append(
            _testImage.rectTransform.
            DOScale(new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), 1.0f), Random.Range(3, 5) ).
            SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
        
        yield return new WaitForSeconds(3);
        StartCoroutine(Animation());
    }
}
