using DevStory.Interfaces;
using DevStory.Managers;
using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    public class Rotator : MonoBehaviour,ISelected
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private bool allowRotation = false;

        private Vector3 previousPosition = Vector3.zero;
        private float difference;

        [SerializeField] private float rotationAmount = 30f;
        private float direction = 0;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            previousPosition = Input.mousePosition;
            PointManager.Instance.SelectSprite(this);

            difference = 0f;
            direction = 0f;
            allowRotation = true;
        }

        private void OnMouseDrag()
        {
            difference = Input.mousePosition.x - previousPosition.x;

            direction = difference >= 0f ? 1 : -1;
          
        }

        private void OnMouseUp()
        {
            previousPosition = Vector3.zero;
            PointManager.Instance.ResetSelected();

            difference = 0f;
            direction = 0f;
            allowRotation = false;
        }

        private void LateUpdate()
        {
            if (!allowRotation) return;

            RotationUpdater();
        }

        private void RotationUpdater()
        {
            Debug.Log($"Rotating will happen in here:{difference}");

            transform.Rotate(0,0f,direction * rotationAmount * Time.deltaTime);
            previousPosition = Input.mousePosition;

        }
    }
}
