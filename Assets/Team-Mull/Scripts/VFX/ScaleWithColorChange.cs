using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

namespace DevStory.VFX
{

    public class ScaleWithColorChange : ScaleWithCurve
    {
        [SerializeField]
        private TextMeshProUGUI colorText;

        [SerializeField]
        private float resetAfter;

        [SerializeField]
        private Color originalColor;

        [SerializeField]
        private Color scaleColor;


        public override void ResetScale()
        {
            base.ResetScale();

            colorText.color = originalColor;
        }

        public override void ScaleTween()
        {
            base.ScaleTween();

            colorText.color = scaleColor;

            Invoke("ResetScale",resetAfter);
        }


        //Pointer handlers
        public override void OnPointerEnter(PointerEventData eventData)
        {
            //base.OnPointerEnter(eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            // base.OnPointerExit(eventData);
        }
    }
}
