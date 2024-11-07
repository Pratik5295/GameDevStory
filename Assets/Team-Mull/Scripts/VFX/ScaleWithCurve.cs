using UnityEngine;
using DG.Tweening;

namespace DevStory.VFX
{
    /// <summary>
    /// A generic script
    /// </summary>
    public class ScaleWithCurve : MonoBehaviour
    {
        [SerializeField]
        private float scaleAmount;

        private Vector3 targetScale;

        [SerializeField]
        private AnimationCurve curve;

        [SerializeField]
        private float duration;

        private void Start()
        {
            targetScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
            ScaleTween();
        }

        public void ScaleTween()
        {
            DOTween.To(
                () => transform.localScale,
                x => transform.localScale = x,
                targetScale, duration).SetEase(curve).SetLoops(-1, LoopType.Yoyo);
        }

    }
}
