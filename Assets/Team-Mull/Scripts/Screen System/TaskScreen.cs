using DevStory.Managers;
using DevStory.TaskSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DevStory.UI
{
    /// <summary>
    /// This script will extend the base screen and implement
    /// the UI for task screen and hold data of relevant tasks
    /// </summary>
    
    [DefaultExecutionOrder(3)]
    public class TaskScreen : Screen
    {
        [SerializeField]
        private TaskColumn toDoColumn;

        [SerializeField] private TaskManager taskManager;

        private void Start()
        {
            taskManager = TaskManager.Instance;
            taskManager.OnCurrentTasksUpdated += OnTaskListUpdatedHandler;
        }

        private void OnDestroy()
        {
            taskManager.OnCurrentTasksUpdated -= OnTaskListUpdatedHandler;
        }

        private void OnTaskListUpdatedHandler(List<GameTask> taskList)
        {
            toDoColumn.ClearColumn();
            foreach (GameTask task in taskList)
            {
                toDoColumn.CreateNewTask(task);
            }
        }
    }
}
