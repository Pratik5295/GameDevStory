using UnityEngine;
using UnityEngine.EventSystems;

namespace DevStory.Utility.UI
{
    public class UISelector : MonoBehaviour, IPointerDownHandler
    {
        /// <summary>
        /// When pointer drops on this, it will select the rect transform
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            RectSelectorManager.Instance.SetSelectedTransform(GetComponent<RectTransform>());
        }
    }
}
