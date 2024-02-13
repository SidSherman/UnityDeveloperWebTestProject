using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageAnimator : MonoBehaviour
{
    [SerializeField] private Image _testImage;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        // Start after one second delay (to ignore Unity hiccups when activating Play mode in Editor)
        yield return new WaitForSeconds(1);
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_testImage.rectTransform.DORotate(new Vector3(0.0f, 0.0f, Random.value), Random.Range(1,5), RotateMode.LocalAxisAdd).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo));

        sequence.Append(_testImage.rectTransform.DOScale(new Vector3(0.0f, 0.0f, Random.value), Random.Range(1, 5)).SetEase(Ease.InQuad).SetLoops(2, LoopType.Yoyo));

    }

}
