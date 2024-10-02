using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    public class Holder : MonoBehaviour
    {
        [SerializeField] private PuzzlePieceVal CorrectValue;

        [SerializeField] private Piece heldPiece;

        [SerializeField] private PuzzlePieceResponse Response;

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
                Response = PuzzlePieceResponse.FAIL;
                Debug.Log("No piece by default failure response");
                return;
            }

            if(heldPiece.Value == CorrectValue)
            {
                Response = PuzzlePieceResponse.SUCCESS;
                Debug.Log("Correct piece has been placed");
            }
            else
            {
                Response = PuzzlePieceResponse.FAIL;
                Debug.Log("Wrong response has been placed!");
            }
        }
    }
}
