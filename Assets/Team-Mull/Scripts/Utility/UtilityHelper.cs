using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Utility
{
    /// <summary>
    /// A static class for utility helper functions
    /// Add all methods that are somewhere generic in this script
    /// </summary>
  

    public static class UtilityHelper
    {
        public static GameScreens GetScreenIntegerFromTaskType(TaskType _taskType)
        {
            switch(_taskType)
            {
                default:
                    return GameScreens.MAIN;

                case TaskType.DEFAULT:
                    return GameScreens.MAIN;

                case TaskType.PAINT:
                    return GameScreens.PAINT;

                case TaskType.PROGRAM:
                    return GameScreens.EDITOR;

            }
        }


        public static string ConvertTimeFormat(float timer)
        {
            float minutesPassed = timer / 60f;
            int hours = (int)minutesPassed;
            int minutes = (int)((minutesPassed - hours) * 60f);

            //Starting from 9 am
            int startHour = 9;
            int displayHours = startHour + hours % 24;
            string period = "AM";
            int displayMinutes = minutes;

            if(displayHours >= 12)
            {
                period = "PM";

                if (displayHours > 12) displayHours -= 12;
            }
            else if(displayHours == 0)
            {
                displayHours = 12;
            }

            return string.Format($"{displayHours:D2}:{displayMinutes:D2} {period}");
        }


        public static Vector3 GetMousePos(Camera _camera, GameObject gameObject)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = _camera.WorldToScreenPoint(gameObject.transform.position).z;

            return _camera.ScreenToWorldPoint(mousePoint);
        }
    }
}
