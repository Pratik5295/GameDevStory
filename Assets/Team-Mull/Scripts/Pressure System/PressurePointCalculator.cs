using DevStory.TaskSystem;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.PressureSystem
{
    /// <summary>
    /// A Utility helper class to calculate the amount of pressure the player
    /// will be awarded will be based on the result of task
    /// </summary>
    public static class PressurePointCalculator
    {
        public static int GetPressurePoints(TaskResultSaver _result)
        {
            int priorityFactor = GetTaskPriorityFactor(_result.Priority);

            int resultFactor = GetTaskResultFactor(_result.Result);

            //Multiply by pressure factor before returning the pressure
            return (priorityFactor * resultFactor);    
        }

        private static int GetTaskPriorityFactor(TaskPriority _priority)
        {
            switch(_priority)
            {
                case TaskPriority.DEFAULT:
                    return 0;

                case TaskPriority.HIGH:
                    return 5;

                case TaskPriority.MEDIUM: 
                    return 2;

                case TaskPriority.LOW:
                    return 1;
            }

            return 0;
        }


        private static int GetTaskResultFactor(TaskResult _result)
        {
            switch (_result)
            {
                case TaskResult.FAILURE:
                    return 10;

                case TaskResult.COMPLETED_PAST_DEADLINE:
                    return 5;

                case TaskResult.COMPLETED:
                    return -5;
            }

            return 0;
        }
    }
}
