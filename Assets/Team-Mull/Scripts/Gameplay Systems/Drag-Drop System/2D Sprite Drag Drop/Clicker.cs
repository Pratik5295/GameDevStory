using DevStory.Interfaces;
using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    public class Clicker : MonoBehaviour,IChangeable
    {
        public virtual void IterateValue()
        {
         
        }

        private void OnMouseDown()
        {
            Debug.Log($"Click detected on: {gameObject.name}");
            IterateValue();
        }
    }
}
