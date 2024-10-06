using DevStory.Gameplay.DragDrop;
using DevStory.Interfaces;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    /// <summary>
    /// This script will be attached on each puzzle piece
    /// This will act as the base class holding only the value of 
    /// each of the puzzle piece to be verified with the holder
    /// 
    /// This script will be the base script to be extended by all types of puzzles pieces
    /// </summary>
    public class Piece : MonoBehaviour,IDroppable
    {
        [SerializeField] protected PuzzlePieceVal PieceValue;

        public PuzzlePieceVal Value => PieceValue;

        [SerializeField] private Dragger dragger;

        [SerializeField] protected Collider2D collidedWith;

        [SerializeField] private Vector3 originalPosition;

        private void Start()
        {
            dragger = GetComponent<Dragger>();
            dragger.OnElementDroppedEvent += Drop;

            originalPosition = transform.position;
        }

        private void OnDestroy()
        {
            dragger.OnElementDroppedEvent -= Drop;
        }

        public void ForceBackToOriginalPosition()
        {
            transform.position = originalPosition;
        }


        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Place")
            {
                collidedWith = collision;
                
            }
        }

        protected virtual void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Place")
            {
                collidedWith = collision;

            }
        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Place")
            {
                if (collidedWith == null) return;

                var holder =
                    collidedWith.gameObject.GetComponent<IHoldable>();
                holder.PieceRemoved();

                collidedWith = null;
            }
        }


        //Droppable interface handling method
        public virtual void Drop()
        {
            if (collidedWith == null) return;

            var holder =
                    collidedWith.gameObject.GetComponent<IHoldable>();

            holder.PiecePlaced(this);
        }
    }
}
