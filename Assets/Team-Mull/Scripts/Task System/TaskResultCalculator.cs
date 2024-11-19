
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.TaskSystem
{
    public static class TaskResultCalculator
    {
        /// <summary>
        /// Task result calculator based on task related factors
        /// </summary>
        /// <param name="_validityCheck">Validity Check recieved from the puzzle</param>
        /// <param name="eventFireDay">Day the event was fired on</param>
        /// <param name="eventDeadline">Deadline for event submission in terms of float value</param>
        /// <param name="eventSubmitDay">Day the event was submitted on</param>
        /// <param name="eventSubmitTime">Time the event was submitted on</param>
        /// <returns></returns>
        public static TaskResult GetTaskResult(bool _validityCheck, int eventFireDay, float eventDeadline, float eventSubmitDay, float eventSubmitTime)
        {
            if (!_validityCheck)
            {
                //Task submitted was not 100% accurate
                return TaskResult.FAILURE;
            }
            else
            {
                //Submitted on the same day
                if(eventFireDay <= eventSubmitDay)
                {
                    //Check for submitted within time
                    if(eventDeadline >= eventSubmitTime)
                    {
                        //Submitted within deadline
                        return TaskResult.COMPLETED;
                    }
                    else
                    {
                        //Submitted past deadline
                        return TaskResult.COMPLETED_PAST_DEADLINE;
                    }

                }
                else
                {
                    //Late submission

                    return TaskResult.COMPLETED_PAST_DEADLINE;
                }
            }
        }
    }
}
