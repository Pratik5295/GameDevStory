using DevStory.Gameplay.GameTimer;
using DevStory.Interfaces.UI;
using DevStory.TaskSystem;
using DevStory.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Managers
{
    [DefaultExecutionOrder(1)]
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

        [SerializeField]
        private ExperienceSystem experienceSystem;

        //Experience System Getter
        public ExperienceSystem GetExperienceSystem => experienceSystem;

        [SerializeField]
        private GameTimerManager gameTimerManager;

        private void Start()
        {
            gameTimerManager = GameTimerManager.Instance;

            if(gameTimerManager != null)
            {
                gameTimerManager.OnDayEndedEvent += OnDayEndedHandler;
            }
            else
            {
                Debug.LogError("Missing Game Timer Manager",gameObject);
            }
        }

        private void OnDestroy()
        {
            if(gameTimerManager != null)
            {
                gameTimerManager.OnDayEndedEvent -= OnDayEndedHandler;
            }
        }

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
                //Update the performance reviewer with result
                if (performanceReviewer != null)
                {
                    performanceReviewer.UpdateResult(_task, _result);
                }
                else
                {
                    Debug.LogError("Performance reviewer component is missing");
                }

                //Update the experience system with result
                AddExperience(_result.ExperienceGained);
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

        public void ResetCurrentTask()
        {
            DeactivateAllTasks();

            if (activeTask != null)
            {
                //Reset task only if a task was selected
                currentTasks[activeTask].gameObject.SetActive(false);

                activeTask = null;
            }
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

        public void AddExperience(int _xp)
        {
            if(experienceSystem == null)
            {
                Debug.LogWarning("Experience system is currently missing");
                return;
            }

            experienceSystem.AddExp(_xp);
        }


        private void OnDayEndedHandler()
        {
            //Everything related to day end will be fired

            //Reset current task to null
            ResetCurrentTask();
        }
    }
}
