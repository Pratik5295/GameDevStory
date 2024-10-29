using DevStory.Managers;
using DevStory.TaskSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DevStory.UI
{
    /// <summary>
    /// This script will extend the base screen and implement
    /// the UI for task screen and hold data of relevant tasks
    /// NOTE: Keep this screen active in hierarchy
    /// </summary>
    
    [DefaultExecutionOrder(3)]
    public class TaskScreen : Screen
    {
        [SerializeField]
        private TaskColumn toDoColumn;

        [SerializeField] private TaskManager taskManager;

        private void Awake()
        {
            taskManager = TaskManager.Instance;
            taskManager.OnCurrentTasksUpdated += OnTaskListUpdatedHandler;
        }

        private void Start()
        {
            //Force it active so the listeners are active
            Close();
        }

        private void OnDestroy()
        {
            taskManager.OnCurrentTasksUpdated -= OnTaskListUpdatedHandler;
        }

        private void OnTaskListUpdatedHandler(Dictionary<GameTask,GameObject> taskList)
        {
            toDoColumn.ClearColumn();
            foreach (var task in taskList)
            {
                toDoColumn.CreateNewTask(task.Key);
            }
        }
    }
}
