using DevStory.Interfaces;
using DevStory.Managers;
using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    public class Rotator : MonoBehaviour,ISelected
    {
        private void OnMouseDown()
        {
            PointManager.Instance.SelectSprite(this);
        }

        private void OnMouseDrag()
        {
            Debug.Log("Rotating will happen in here");
        }

        private void OnMouseUp()
        {
            PointManager.Instance.ResetSelected();
        }
    }
}
