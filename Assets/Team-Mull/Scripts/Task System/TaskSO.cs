using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// The game task structure data that will be used throughout the whole project
    /// </summary>

    [System.Serializable]
    public struct GameTaskData
    {
        public string TaskName;
        public TaskPriority Priority;
        public TaskType Type;

        [TextArea(3,12)]
        public string Description;

        public CharacterDataSO SupervisorData; 

        //Can I add game object
        public GameObject TaskPrefab;   //Translates to the puzzle prefab

        //The float deadline in float numbers where 0 is 9 am and 480 is 5pm
        [Tooltip("Enter value between 0f to 480f for 9am to 5pm")]
        [Range(0,480)]
        public float Deadline;
    }


    /// <summary>
    /// The scriptable object script that will be responsible for the 
    /// creation of the Task Scriptable object data
    /// </summary>
    /// 
    [CreateAssetMenu(fileName = "TaskSO", menuName ="Task System/Create a new Task")]
    public class TaskSO : ScriptableObject
    {
        public GameTaskData TaskData;

    }
}
