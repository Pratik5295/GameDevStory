
namespace MetaConstants.EnumManager
{
    /// <summary>
    /// A static class to hold the references to enums being used in the game
    /// </summary>
    public static class EnumManager
    {
        public enum ScreenState
        {
            CLOSED = 0,
            OPENED = 1
        }

        public enum DialogMessageType
        {
            DEFAULT = 0,
            ENDER = 1
        }

        #region Puzzle Handling Enums

        /// <summary>
        /// This enum value will be used by puzzles(Holder and Piece)
        /// to determine if it is being placed on the right spot
        /// </summary>
        public enum PuzzlePieceVal
        {
            DEFAULT = 0,
            ONE = 1,
            TWO = 2,
            THREE = 3,
            FOUR = 4
        }

        /// <summary>
        /// This refers to responses of each piece of the puzzle
        /// </summary>
        public enum PuzzlePieceResponse
        {
            FAIL = 0,
            SUCCESS = 1
        }

        /// <summary>
        /// This refers to the status of the entire puzzle
        /// </summary>
        public enum PuzzleStatus
        {
            UNSOLVED = 0,
            SOLVED = 1
        }

        #endregion
    }
}
