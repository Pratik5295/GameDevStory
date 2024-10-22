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
            int pressure = 0;

            //If the pressure is to be reduced, then the factor would be -1
            int pressureFactor = 1; 
           
            //Check status if the task is completed (submitted)
            if(_result.Status == TaskStatus.COMPLETED)
            {
                //Task was completed, award pressure
                pressureFactor = -1;
            }
            else
            {
                pressureFactor = 1;
            }

            //Check the task priority to adjust the pressure
            switch(_result.Priority)
            {
                case TaskPriority.DEFAULT:
                    pressure = 1;
                    break;
                case TaskPriority.HIGH:
                    pressure = 10;
                    break;
                case TaskPriority.MEDIUM:
                    pressure = 6;
                    break;
                case TaskPriority.LOW:
                    pressure = 4;
                    break;
            }

            //Multiply by pressure factor before returning the pressure
            return (pressureFactor * pressure);    
        }
    }
}
