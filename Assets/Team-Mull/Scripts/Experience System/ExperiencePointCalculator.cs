using DevStory.TaskSystem;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Experience
{
    public static class ExperiencePointCalculator
    {
        public static int GetExperience(TaskResultSaver _result)
        {
            int exp = 0;

            switch (_result.Priority)
            {
                case TaskPriority.DEFAULT:
                    exp = 1;
                    break;
                case TaskPriority.HIGH:
                    exp = 12;
                    break;
                case TaskPriority.MEDIUM:
                    exp = 8;
                    break;
                case TaskPriority.LOW:
                    exp = 4;
                    break;
            }

            return exp;
        }
    }
}
