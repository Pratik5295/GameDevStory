using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    public class Dragger : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        [SerializeField] private Vector3 offset;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            offset = transform.position - GetMousePos();
        }

        private void OnMouseDrag()
        {
            transform.position = GetMousePos() + offset;
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
