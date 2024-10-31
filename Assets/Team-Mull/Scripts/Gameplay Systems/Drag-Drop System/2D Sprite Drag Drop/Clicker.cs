using DevStory.Interfaces;
using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    public class Clicker : MonoBehaviour
    {

        private void OnMouseDown()
        {
            Debug.Log($"Selected item is: {gameObject.name} & {gameObject.tag}");
        }
    }
}
