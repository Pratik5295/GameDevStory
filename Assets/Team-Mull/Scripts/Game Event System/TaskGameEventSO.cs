using DevStory.TaskSystem;
using UnityEngine;

namespace DevStory.GameEventSystem
{
    //This event fires a new task on its own in the game

    [CreateAssetMenu(fileName = "Task Game Event SO", menuName = "Game Events/Game Tasks/Create a New Task Event")]

    public class TaskGameEventSO : GameEventSO
    {
        //Associated game task to be created with the SO
        public TaskSO gameTask;
        public override void Execute()
        {
            base.Execute();

            GameObject go = new GameObject($"Task-{gameTask.TaskData.TaskName}");
            GameTask gameTaskObj = go.AddComponent<GameTask>();

            gameTaskObj.AddTaskToManager(gameTask);

        }
    }
}
