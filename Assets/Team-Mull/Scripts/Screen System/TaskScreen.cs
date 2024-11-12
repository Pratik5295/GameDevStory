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


        [SerializeField]
        private GameObject noTaskScreen;


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

        private void Update()
        {
            if (noTaskScreen == null) return;

            if(taskManager.GetCurrentTask == null)
            {
                noTaskScreen.SetActive(true);
            }
            else
            {
                noTaskScreen.SetActive(false);
            }
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
