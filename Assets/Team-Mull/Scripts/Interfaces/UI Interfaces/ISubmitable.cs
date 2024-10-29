namespace DevStory.Interfaces
{
    /// <summary>
    /// This interface will be added on the scripts that will hold the logic to 
    /// the submitting of the task
    /// </summary>
    public interface ISubmitable 
    {
        /// <summary>
        /// On submit button clicked, this interface function will be fired
        /// </summary>
          void SubmitTask();
    }
}
