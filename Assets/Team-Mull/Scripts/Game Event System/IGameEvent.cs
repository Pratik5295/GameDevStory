namespace DevStory.GameEventSystem
{
    /// <summary>
    /// The base interface for handling the execution and raising of events
    /// </summary>
    public interface IGameEvent
    {
        void Execute();
    }
}
