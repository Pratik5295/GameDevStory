using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace DevStory.VFX
{
    /// <summary>
    /// A generic script for scaling an object with animation curve using DOTween
    /// </summary>
    public class ScaleWithCurve : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField]
        private float scaleAmount;

        private Vector3 targetScale;
        private Vector3 originalScale;

        [SerializeField]
        private AnimationCurve curve;

        [SerializeField]
        private float duration;

        private Tween scaleTween;


        private void Start()
        {
            originalScale = transform.localScale;

            targetScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
            
        }

        public void ScaleTween()
        {
            scaleTween = DOTween.To(
                () => transform.localScale,
                x => transform.localScale = x,
                targetScale, duration).SetEase(curve).SetLoops(-1, LoopType.Yoyo);
        }

        public void ResetScale()
        {
            if(scaleTween != null)
            {
                scaleTween.Kill();
            }

            Sequence resetSequence = DOTween.Sequence();

            resetSequence.Append(
                transform.DOScale(originalScale, duration)  // Tween the scale back to original scale
            );

            // Kill the sequence after it finishes
            resetSequence.OnKill(() => transform.localScale = originalScale);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ScaleTween();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetScale();
        }
    }
}
