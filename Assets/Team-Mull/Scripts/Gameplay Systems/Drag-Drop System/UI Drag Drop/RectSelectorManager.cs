using UnityEngine;
using UnityEngine.EventSystems;

namespace DevStory.Utility
{
    public class RectSelectorManager : MonoBehaviour,IPointerUpHandler
    {
        public static RectSelectorManager Instance = null;

        [SerializeField] private RectTransform selectedRectTransform;

        public RectTransform selected => selectedRectTransform;

        public void OnPointerUp(PointerEventData eventData)
        {
            selectedRectTransform = null;
        }

        public void SetSelectedTransform(RectTransform _rectTransform)
        {
            selectedRectTransform = _rectTransform;
        }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
