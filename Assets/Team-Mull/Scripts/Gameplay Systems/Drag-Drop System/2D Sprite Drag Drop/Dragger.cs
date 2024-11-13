using DevStory.Interfaces;
using DevStory.Managers;
using DevStory.Utility;
using System;
using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    /// <summary>
    /// This script will be added on a sprite to drag it when mouse is clicked
    /// </summary>
    public class Dragger : MonoBehaviour, ISelected
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private Vector3 offset;

        [SerializeField] private Vector2 spriteSize;
        [SerializeField] private Vector2 spriteHalfSize;

        //Check flag if you dont want the piece to be dragged
        [Tooltip("Check flag if you want the piece to not move")]
        public bool lockMovement = false;

        public Action OnElementPickedEvent;
        public Action OnElementDroppedEvent;

        private void Start()
        {
            mainCamera = Camera.main;

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteSize = spriteRenderer.sprite.bounds.size;
            spriteHalfSize = spriteRenderer.sprite.bounds.extents;
        }

        private void OnMouseDown()
        {
            if (lockMovement) return;

            offset = transform.position - UtilityHelper.GetMousePos(mainCamera,gameObject);

            PointManager.Instance.SelectSprite(this);
            OnElementPickedEvent?.Invoke();
        }

        private void OnMouseDrag()
        {
            if (lockMovement) return;

            //Check screen limits
            Vector3 newPos = UtilityHelper.GetMousePos(mainCamera, gameObject) + offset;


            transform.position = newPos;
        }

        private void OnMouseUp()
        {
            if (lockMovement) return;

            PointManager.Instance.ResetSelected();

            OnElementDroppedEvent?.Invoke();
        }

        private void LateUpdate()
        {
            if (lockMovement) return;

            LateMovementUpdater();
        }

        #region Movement Handlers

        private void LateMovementUpdater()
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

        #endregion

    }
}
