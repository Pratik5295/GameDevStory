using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseScrollForScrollView : MonoBehaviour, IPointerEnterHandler,
    IPointerExitHandler
{
    public ScrollRect scrollRect;  // Drag the ScrollRect component here in the Inspector
    public float scrollSpeed = 25f; // You can adjust the scroll speed
    public float smoothFactor = 5f; // Adjust this to control smoothing speed

    [SerializeField]
    private bool isSelected;


    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isSelected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelected = false;
    }

    void Update()
    {
        if (!isSelected) return;

        // Get the scroll wheel input (positive for scroll up, negative for scroll down)
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // If the user is scrolling, adjust the content's vertical position
        if (scrollInput != 0f)
        {
            // Scroll vertically based on the scroll wheel input
            float targetPosition = scrollRect.verticalNormalizedPosition + scrollInput * scrollSpeed;

            // Smoothly interpolate towards the target position
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, targetPosition, Time.deltaTime * smoothFactor);


            // Clamp the value to prevent going out of bounds
            scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition);
        }
    }
}
