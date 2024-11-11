using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DevStory.VFX
{

    public class IndentOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private float offsetX;

        private Vector3 originalPosition;

        [SerializeField]
        private float duration;

        private Tween activeTween;

        private void OnMoveTween()
        {
            originalPosition = transform.localPosition;
            activeTween = transform.DOLocalMoveX(transform.localPosition.x + offsetX, duration);
        }

        private void ResetTween()
        {
            if (activeTween != null)
            {
                activeTween.Kill();
            }

            transform.DOLocalMove(originalPosition, duration);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnMoveTween();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ResetTween();
        }
    }
}
