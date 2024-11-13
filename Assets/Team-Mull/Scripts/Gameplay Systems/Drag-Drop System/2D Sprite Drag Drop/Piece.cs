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

        [SerializeField] protected Collider2D previousCollider;
        [SerializeField] protected Collider2D collidedWith = null;

        [SerializeField]
        protected IHoldable localHolder;

        [SerializeField] private Vector3 originalPosition;

        [SerializeField] private Transform rayFirePoint;

        [SerializeField] private LayerMask layerToIgnore;

        private void Awake()
        {
            dragger = GetComponent<Dragger>();
            dragger.OnElementDroppedEvent += Drop;

            originalPosition = transform.position;
        }

        private void OnDestroy()
        {
            dragger.OnElementDroppedEvent -= Drop;
        }

        private void Update()
        {
            //CheckForRaycastHit();
        }

        public void ForceBackToOriginalPosition()
        {
            transform.position = originalPosition;
        }


        //Droppable interface handling method
        public virtual void Drop()
        {
            Debug.Log("Dropping piece", gameObject);

            CheckForRaycastHit();

            if (collidedWith == null) return;

            localHolder =
                    collidedWith.gameObject.GetComponent<IHoldable>();

            localHolder.PiecePlaced(this);
        }

        protected void CheckForRaycastHit()
        {
            // Cast a ray in forward direction
            RaycastHit2D hit = 
                Physics2D.Raycast(rayFirePoint.position,
                Vector3.forward,20,~layerToIgnore);

            if(hit)
            {
                if(hit.collider.gameObject.tag == "Place")
                {
                    collidedWith = hit.collider;
                    
                }
                else
                {
                    collidedWith = null;
                    localHolder = null;
                }
            }
            else
            {
                if(collidedWith != null)
                {
                    localHolder = collidedWith.gameObject.GetComponent<IHoldable>();
                    localHolder.PieceRemoved(this);
                }

                collidedWith = null;
                localHolder = null;
            }
        }
    }
}
