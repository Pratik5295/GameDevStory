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
    }
}
