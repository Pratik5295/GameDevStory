using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static MetaConstants.EnumManager.EnumManager;
using DevStory.Utility;
using DG.Tweening;

namespace DevStory.VFX
{
    public class ScaleAndReset : ScaleWithCurve
    {

        [SerializeField]
        private Image glowImage;

        [SerializeField]
        private float resetAfter;


        public void SetNewColor(PuzzlePaint _paint)
        {
            Color color = ColorCoder.GetColor(_paint);

            glowImage.color = color;

            ScaleTween();
        }

        public override void ScaleTween()
        {
            scaleTween = DOTween.To(
                 () => transform.localScale,
                 x => transform.localScale = x,
                 targetScale, duration);
 
             Invoke("ResetScale", duration + resetAfter);
        }

        //Pointer handlers
        public override void OnPointerEnter(PointerEventData eventData)
        {
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}
