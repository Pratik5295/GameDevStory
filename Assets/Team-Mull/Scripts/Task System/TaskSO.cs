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

        //Supervisor section, will be turned into a character tool with enum?
        public Sprite SupervisorSprite;
        public string SupervisorName;   

        //Can I add game object
        public GameObject TaskPrefab;   //Translates to the puzzle prefab
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
