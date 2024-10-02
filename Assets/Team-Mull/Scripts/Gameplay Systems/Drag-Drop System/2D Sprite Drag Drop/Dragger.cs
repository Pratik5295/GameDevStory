using DevStory.Utility;
using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    /// <summary>
    /// This script will be added on a sprite to drag it when mouse is clicked
    /// </summary>
    public class Dragger : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private Vector3 offset;

        [SerializeField] private Vector2 spriteSize;
        [SerializeField] private Vector2 spriteHalfSize;

        private void Start()
        {
            mainCamera = Camera.main;

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteSize = spriteRenderer.sprite.bounds.size;
            spriteHalfSize = spriteRenderer.sprite.bounds.extents;
        }

        private void OnMouseDown()
        {
            offset = transform.position - GetMousePos();
        }

        private void OnMouseDrag()
        {
            //Check screen limits
            Vector3 newPos = GetMousePos() + offset;


            transform.position = newPos;
        }

        private void LateUpdate()
        {
            // get the sprite's edge positions
            float spriteLeft = transform.position.x - spriteHalfSize.x;
            float spriteRight = transform.position.x + spriteHalfSize.x;
            float spriteBottom = transform.position.y - spriteHalfSize.y;
            float spriteTop = transform.position.y + spriteHalfSize.y;

            // initialize the new position to the current position
            Vector3 clampedPosition = transform.position;

            // if any of the edges surpass the camera's bounds,
            // set the position TO the camera bounds (accounting for sprite's size)
            if (spriteLeft < GameWindow.Instance.horizontalLimits.x)
            {
                clampedPosition.x = GameWindow.Instance.horizontalLimits.x + spriteHalfSize.x;
            }
            else if (spriteRight > GameWindow.Instance.horizontalLimits.y)
            {
                clampedPosition.x = GameWindow.Instance.horizontalLimits.y - spriteHalfSize.x;
            }

            if (spriteTop > GameWindow.Instance.verticalLimits.x)
            {
                clampedPosition.y = GameWindow.Instance.verticalLimits.x - spriteHalfSize.y;
            }
            else if (spriteTop < GameWindow.Instance.verticalLimits.y)
            {
                clampedPosition.y = GameWindow.Instance.verticalLimits.y + spriteHalfSize.y;
            }

            transform.position = clampedPosition;
        }




        private Vector3 GetMousePos()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;

            return mainCamera.ScreenToWorldPoint(mousePoint);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Place")
            {
                Debug.Log("Placer has been found");
            }
        }
    }
}
