

using DevStory.Gameplay.Puzzles;

namespace DevStory.Interfaces
{
    /// <summary>
    /// This interface will be extended on all the placer/holder objects
    /// It will comprise of the methods fired when a piece is placed or removed from the placer
    /// </summary>
    public interface IHoldable
    {
        /// <summary>
        /// Method will be fired when a piece has been placed on the placer.
        /// This script will be further extend
        /// </summary>
        void PiecePlaced(Piece piece);


        /// <summary>
        /// Method will be fired when a piece has been removed from the placer
        /// </summary>
        void PieceRemoved(Piece piece);
    }
}
