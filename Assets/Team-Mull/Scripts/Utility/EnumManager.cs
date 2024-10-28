
namespace MetaConstants.EnumManager
{
    /// <summary>
    /// A static class to hold the references to enums being used in the game
    /// </summary>
    public static class EnumManager
    {
        #region Screen Related Enums
        public enum ScreenState
        {
            CLOSED = 0,
            OPENED = 1
        }

        //Unused at the moment
        public enum GameScreens
        {
            MAIN = 0,
            ENGINE = 1,
            PAINT = 2,
            EDITOR = 3,
            EMAIL = 4,
            TASK = 5

        }

        #endregion

        #region Dialogue Related Enums

        public enum DialogMessageType
        {
            DEFAULT = 0,
            ENDER = 1
        }

        #endregion

        #region Game Task System Enums

        public enum TaskPriority
        {
            DEFAULT = 0,
            LOW = 1,
            MEDIUM = 2,
            HIGH = 3
        }

        public enum TaskType
        {
            DEFAULT = 0,
            PAINT = 1,
            PROGRAM = 2
        }

        public enum TaskStatus
        {
            DEFAULT = 0,
            TODO = 1,
            INPROGRESS = 2,
            COMPLETED = 3,  
        }

        #endregion

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
            DEFAULT = 0,
            FAIL = 1,
            SUCCESS = 2
        }

        /// <summary>
        /// This refers to the status of the entire puzzle
        /// </summary>
        public enum PuzzleStatus
        {
            UNSOLVED = 0,
            SOLVED = 1
        }

        public enum PuzzlePaint
        {
            WHITE = 0,
            RED = 1,
            YELLOW = 2,
            GREEN = 3,
            BLUE = 4,
            ORANGE = 5
        }

        /// <summary>
        /// Enum handler to determine what kind of float value you changing
        /// This will be used on the audio puzzle
        /// </summary>
        /// 

        public enum AudioMeasurements
        {
            FREQUENCY = 0,
            AMPLITUDE = 1
        }

        #endregion

        #region Character Enums

        // Will turn this into a tool?
        public enum Characters
        {

        }

        #endregion
    }
}
