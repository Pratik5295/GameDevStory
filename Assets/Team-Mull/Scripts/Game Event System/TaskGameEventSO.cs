using DevStory.Managers;
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

            //Spawns task prefab activity
            GameObject puzzleObject = LoadActivity();

            gameTaskObj.AddTaskToManager(gameTask, puzzleObject);

        }

        /// <summary>
        /// Have the game load your puzzle at runtime and assign it with 
        /// the relevant screen manager
        /// </summary>
        public GameObject LoadActivity()
        {
            if (gameTask.TaskData.TaskPrefab == null) return null;

            GameObject go =
                Instantiate(gameTask.TaskData.TaskPrefab,
                Vector3.zero,
                Quaternion.identity);

            go.transform.SetParent(PuzzleManager.Instance.GetParentReference(gameTask.TaskData));

            return go;
        }
    }
}
