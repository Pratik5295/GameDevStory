using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{

    public class IteratorHolder : Holder
    {
        public override void CheckResponse()
        {
           if(heldPiece == null)
           {
                response = PuzzlePieceResponse.FAIL;
           }
            else
            {
               if(heldPiece.gameObject.TryGetComponent<IteratorPiece>(out var iteratorPiece))
               {
                    if(heldPiece.Value == CorrectValue && iteratorPiece.HasIteratorsBeenSolved())
                    {
                        //Correct piece placed
                        response = PuzzlePieceResponse.SUCCESS;
                    }
                    else
                    {
                        response = PuzzlePieceResponse.FAIL;
                    }
                }
                else
                {
                    //Remove this condition if we are going for only Iterators for the puzzle
                    if (heldPiece.Value == CorrectValue)
                    {
                        response = PuzzlePieceResponse.SUCCESS;
                    }
                    else
                    {
                        response = PuzzlePieceResponse.FAIL;
                    }
                }
            }

            //Checking if the response received is any different from the one already saved
            if (previousResponse != PuzzlePieceResponse.DEFAULT)
            {
                //Response was changed from default

                if (response != previousResponse)
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

        public override void PiecePlaced(Piece _piece)
        {
            //Overriding this class to not allow the piece to go back to its original position
            heldPiece = _piece;

            //Check response of the piece that is placed
            CheckResponse();
        }


    }
}
