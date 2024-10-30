using DevStory.Interfaces.UI;
using DevStory.TaskSystem;
using DevStory.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Managers
{
    public class TaskManager : MonoBehaviour, IScreen
    {
        public static TaskManager Instance = null;

        [SerializeField]
        private TaskDialog taskDialogScreen;

        [SerializeField] private GameTask activeTask;

        public GameTask GetCurrentTask => activeTask;

        [SerializeField] private Dictionary<GameTask,GameObject> currentTasks = new Dictionary<GameTask,GameObject>();

        public Action<Dictionary<GameTask,GameObject>> OnCurrentTasksUpdated;

        [Space(10)]
        [Header("Components")]

        [SerializeField]
        private PerformanceReviewer performanceReviewer;
        
        public void AddNewTask(GameTask _task, GameObject _puzzleObject,TaskResultSaver _result)
        {
            if (!currentTasks.ContainsKey(_task))
            {
                currentTasks.Add(_task, _puzzleObject);
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
            if (!currentTasks.ContainsKey(_task))
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
            if (currentTasks.ContainsKey(_task))
            {
                currentTasks.Remove(_task);
                OnCurrentTasksUpdated?.Invoke(currentTasks);
            }
        }

        public void ClearAllTasks()
        {
            foreach (var _task in currentTasks)
            {
                Destroy(_task.Key.gameObject);
                Destroy(_task.Value.gameObject);
            }
            currentTasks.Clear();

        }

        public void DeactivateAllTasks()
        {
            foreach (var _task in currentTasks)
            {
                _task.Value.gameObject.SetActive(false);
            }
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
            DeactivateAllTasks();

            activeTask = _task;

            currentTasks[activeTask].gameObject.SetActive(true);
        }

        public void OnTaskSubmittedButtonClicked()
        {
            activeTask.TaskCompleted();

            Debug.Log("Task has been completed, now close and discard this puzzle");

            //Remove active task from the list
            RemoveTask(activeTask);

            //Change screen to task screen
            ScreenManager.Instance.ScreenChange(GameScreens.TASK);
        
        }
    }
}
