using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Interfaces
{
    /// <summary>
    /// This script will be attached on all the sprites that would change their color
    /// when interacted by some object in the game
    /// </summary>
    public interface IColorChangeable
    {

        void ChangeColor(PuzzlePaint _newPaint);
    }
}
