using DevStory.TaskSystem;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Experience
{
    public static class ExperiencePointCalculator
    {
        public static int GetExperience(TaskResultSaver _result)
        {
            int priorityFactor = GetTaskMuliplyFactor(_result.Priority);

            int taskResultFactor = GetTaskResultFactor(_result.Result);

            return priorityFactor * taskResultFactor;
        }

        private static int GetTaskMuliplyFactor(TaskPriority _priority)
        {
            switch (_priority)
            {
                case TaskPriority.DEFAULT:
                    return 1;

                case TaskPriority.HIGH:
                    return 4;

                case TaskPriority.MEDIUM:
                    return 3;

                case TaskPriority.LOW:
                    return 2;
            }

            return 0;
        }


        private static int GetTaskResultFactor(TaskResult _result)
        {
            switch(_result)
            {
                case TaskResult.FAILURE:
                    return 0;

                case TaskResult.COMPLETED_PAST_DEADLINE:
                    return 2;

                case TaskResult.COMPLETED:
                    return 3;
            }

            return 0;
        }
    }
}
