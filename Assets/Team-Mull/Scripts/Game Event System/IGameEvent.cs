namespace DevStory.GameEvent
{
    /// <summary>
    /// The base interface for handling the execution and raising of events
    /// </summary>
    public interface IGameEvent
    {
        void Execute();
    }
}
