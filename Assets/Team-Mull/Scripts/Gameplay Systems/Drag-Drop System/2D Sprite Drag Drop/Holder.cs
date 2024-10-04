using UnityEngine;
using UnityEngine.Events;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    public class Holder : MonoBehaviour
    {
        [SerializeField] private PuzzlePieceVal CorrectValue;

        [SerializeField] private Piece heldPiece;

        [SerializeField] private PuzzlePieceResponse response;
        private PuzzlePieceResponse previousResponse = PuzzlePieceResponse.DEFAULT;

        public PuzzlePieceResponse Response => response;

        public UnityEvent<PuzzlePieceResponse> OnResponseChangedEvent;

        public void SetPuzzlePiece(Piece _piece)
        {
            if (heldPiece != null)
            {
                //Return the piece to its original position
                //We cant have more than one piece to be held

                _piece.ForceBackToOriginalPosition();
                return;
            }


            heldPiece = _piece;

            //Check response of the piece that is placed
            CheckResponse();
        }

        public void ResetPuzzlePiece()
        {
            heldPiece = null;

            CheckResponse();
        }

        private void CheckResponse()
        {
            if (heldPiece == null)
            {
                response = PuzzlePieceResponse.FAIL;
                Debug.Log("No piece by default failure response");
                return;
            }

            if(heldPiece.Value == CorrectValue)
            {
                response = PuzzlePieceResponse.SUCCESS;
                Debug.Log("Correct piece has been placed");
            }
            else
            {
                response = PuzzlePieceResponse.FAIL;
                Debug.Log("Wrong response has been placed!");
            }

            if (previousResponse != PuzzlePieceResponse.DEFAULT)
            {
                //Response was changed from default

                if(response != previousResponse)
                {
                    OnResponseChangedEvent?.Invoke(response);
                }
            }
            else
            {
                OnResponseChangedEvent?.Invoke(response);
            }

            previousResponse = response;
        }
    }
}
