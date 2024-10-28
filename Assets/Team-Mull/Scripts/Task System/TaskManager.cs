using DevStory.Interfaces.UI;
using DevStory.TaskSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DevStory.Managers
{
    public class TaskManager : MonoBehaviour, IScreen
    {
        public static TaskManager Instance = null;

        [SerializeField]
        private TaskDialog taskDialogScreen;

        [SerializeField] private GameTask currentTask;

        [SerializeField] private List<GameTask> currentTasks = new List<GameTask>();

        public Action<List<GameTask>> OnCurrentTasksUpdated;

        [Space(10)]
        [Header("Components")]

        [SerializeField]
        private PerformanceReviewer performanceReviewer;
        
        public void AddNewTask(GameTask _task, TaskResultSaver _result)
        {
            if (!currentTasks.Contains(_task))
            {
                currentTasks.Add(_task);
                OnCurrentTasksUpdated?.Invoke(currentTasks);

                if (performanceReviewer != null)
                {
                    performanceReviewer.UpdateResult(_task, _result);
                }
                else
                {
                    Debug.LogError("Performance reviewer component is missing");
                }
            }
        }

        public void UpdateTaskResult(GameTask _task,TaskResultSaver _result)
        {
            if (!currentTasks.Contains(_task))
            {
                Debug.LogWarning($"Task doesn't exist");
            }
            else
            {
                if (performanceReviewer != null)
                {
                    performanceReviewer.UpdateResult(_task, _result);
                }
                else
                {
                    Debug.LogError("Performance reviewer component is missing");
                }
            }
        }

        public void RemoveTask(GameTask _task)
        {
            if (currentTasks.Contains(_task))
            {
                currentTasks.Remove(_task);
                OnCurrentTasksUpdated?.Invoke(currentTasks);
            }
        }

        public void ClearAllTasks()
        {
            foreach (GameTask _task in currentTasks)
            {
                Destroy(_task.gameObject);
            }
            currentTasks.Clear();

        }

        public void Close()
        {
            taskDialogScreen.gameObject.SetActive(false);
        }

        public void Open()
        {
            taskDialogScreen.gameObject.SetActive(true);
        }

        public void OpenTaskDialogBox(GameTask _task)
        {
            SetCurrentTask(_task);
            taskDialogScreen.SetTaskData(_task);

            Open();
        }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetCurrentTask(GameTask _task)
        {
            currentTask = _task;
        }

        public void OnTaskSubmittedButtonClicked()
        {
            currentTask.TaskCompleted();

            Debug.Log("Task has been completed, now close and discard this puzzle");
        }
    }
}
