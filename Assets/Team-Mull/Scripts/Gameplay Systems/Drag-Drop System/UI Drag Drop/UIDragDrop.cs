using DevStory.Utility;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DevStory.Gameplay.DragDrop
{
    public class UIDragDrop : MonoBehaviour, IDragHandler
    {
        [SerializeField]
        private Canvas canvas;


        public void OnDrag(PointerEventData eventData)
        {
            RectSelectorManager.Instance.selected.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

    }
}
