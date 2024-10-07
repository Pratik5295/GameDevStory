
using DevStory.Data;

namespace DevStory.Interfaces
{
    /// <summary>
    /// This interface contains the contract implementation to switch screens
    /// by providing screen change data
    /// </summary>
    public interface IScreenChangeable
    {
        void ChangeScreen(ScreenChangeData screenData);
    }
}
