using DevStory.Gameplay.DragDrop;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    /// <summary>
    /// This script will be attached on each puzzle piece
    /// This will act as the base class holding only the value of 
    /// each of the puzzle piece to be verified with the holder
    /// </summary>
    public class Piece : MonoBehaviour
    {
        [SerializeField] protected PuzzlePieceVal PieceValue;

        public PuzzlePieceVal Value => PieceValue;

        [SerializeField] private Dragger dragger;

        [SerializeField] private Collider2D collidedWith;

        [SerializeField] private Vector3 originalPosition;

        private void Start()
        {
            dragger = GetComponent<Dragger>();
            dragger.OnElementDroppedEvent += OnElementDroppedHandler;

            originalPosition = transform.position;
        }

        private void OnDestroy()
        {
            dragger.OnElementDroppedEvent -= OnElementDroppedHandler;
        }

        private void OnElementDroppedHandler()
        {
            if (collidedWith == null) return;

            var holder =
                    collidedWith.gameObject.GetComponent<Holder>();

            holder.SetPuzzlePiece(this);
        }

        public void ForceBackToOriginalPosition()
        {
            transform.position = originalPosition;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Place")
            {
                Debug.Log("Placer has been found");

                collidedWith = collision;
                
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Place")
            {
                var holder =
                    collidedWith.gameObject.GetComponent<Holder>();
                holder.ResetPuzzlePiece();

                collidedWith = null;
                Debug.Log("Out of placer");
            }
        }
    }
}
