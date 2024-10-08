using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Utility
{
    /// <summary>
    /// A static class for utility helper functions
    /// Add all methods that are somewhere generic in this script
    /// </summary>
  

    public static class UtilityHelper
    {
        public static int GetScreenIntegerFromTaskType(TaskType _taskType)
        {
            switch(_taskType)
            {
                default:
                    return 0;

                case TaskType.DEFAULT:
                    return 0;

                case TaskType.PAINT:
                    return 2;

            }
        }
    }
}
