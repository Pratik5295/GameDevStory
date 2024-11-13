using DevStory.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    public class Holder : MonoBehaviour,IHoldable
    {
        [SerializeField] protected PuzzlePieceVal CorrectValue;

        [SerializeField] protected Piece heldPiece;

        [SerializeField] protected PuzzlePieceResponse response;
        protected PuzzlePieceResponse previousResponse = PuzzlePieceResponse.DEFAULT;

        public PuzzlePieceResponse Response => response;

        public UnityEvent<PuzzlePieceResponse> OnResponseChangedEvent;

        /// <summary>
        /// Holder logic to validate response
        /// </summary>
        public virtual void CheckResponse()
        {
            if (heldPiece == null)
            {
                response = PuzzlePieceResponse.FAIL;
            }
            else
            {
                if (heldPiece.Value == CorrectValue)
                {
                    response = PuzzlePieceResponse.SUCCESS;
                }
                else
                {
                    response = PuzzlePieceResponse.FAIL;
                }
            }

            //Checking if the response received is any different from the one already saved
            if (previousResponse != PuzzlePieceResponse.DEFAULT)
            {
                //Response was changed from default

                if(response != previousResponse)
                {
                    Debug.Log("Response changed!");
                    OnResponseChangedEvent?.Invoke(response);
                }
            }
            else
            {
                OnResponseChangedEvent?.Invoke(response);
            }

            previousResponse = response;
        }

        #region IHoldable interface handling
        public virtual void PiecePlaced(Piece _piece)
        {
            if (heldPiece != null)
            {
                //Return the piece to its original position
                //We cant have more than one piece to be held

                _piece.ForceBackToOriginalPosition();
                CheckResponse();
                return;
            }


            heldPiece = _piece;

            //Check response of the piece that is placed
            CheckResponse();
        }

        public void PieceRemoved(Piece piece)
        {
            if(heldPiece == piece)
            {
                //Removed the piece we were holding 
                heldPiece = null;
            }

            CheckResponse();
        }

        #endregion
    }
}
