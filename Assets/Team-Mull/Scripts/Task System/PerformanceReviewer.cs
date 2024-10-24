using DevStory.Gameplay.GameTimer;
using DevStory.Interfaces.UI;
using DevStory.PressureSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This structure will be used as reference on
    /// what data about the task would be saved in backend
    /// </summary>
    [System.Serializable]
    public struct TaskResultSaver
    {
        public string TaskName;
        public TaskStatus Status;
        public TaskPriority Priority;
        public float Deadline;
        public float SubmissionTime;
        public int SubmissionDay;

        public TaskResultSaver(string _taskName, 
            TaskStatus _status, 
            TaskPriority _priority,
            float _deadline)
        {
            TaskName = _taskName;
            Priority = _priority;
            Status = _status;
            Deadline = _deadline;
            SubmissionTime = -1;    //-1 reflects the task wasnt submitted yet
            SubmissionDay = -1;     // -1 reflects the task wasnt submitted yet
        }
    }

    [DefaultExecutionOrder(5)]
    public class PerformanceReviewer : MonoBehaviour,IScreen
    {
        public Dictionary<GameTask,TaskResultSaver> taskResults = new Dictionary<GameTask,TaskResultSaver>();

        [SerializeField]
        private GameTimerManager gameTimerManager;

        #region Task Results Data Handling
        /// <summary>
        /// This function will be entry point for any data update in the dictionary
        /// Updating any existing result value will also pass through this function
        /// </summary>
        /// <param name="_task"></param>
        /// <param name="_saver"></param>
        public void UpdateResult(GameTask _task, TaskResultSaver _saver)
        {
            if (!taskResults.ContainsKey(_task))
            {
                taskResults.Add(_task, _saver);
            }
        }

        public void RemoveResult(GameTask _task)
        {
            if (taskResults.ContainsKey(_task))
            {
                taskResults.Remove(_task);
            }
        }

        public void ClearAll()
        {
            taskResults.Clear();
        }


        #endregion

        #region Task Results Display Handling

        [Space(10)]
        [Header("Performance Display Variables")]

        [SerializeField]
        private GameObject systemParent;

        [SerializeField]
        private GameObject performanceCardPrefab;

        [SerializeField]
        private Transform cardsParent;

        [SerializeField]
        private Dictionary<GameTask,GameObject> cards = new Dictionary<GameTask,GameObject>();

        private void Start()
        {
            gameTimerManager = GameTimerManager.Instance;

            if(gameTimerManager != null)
            {
                gameTimerManager.OnDayStartedEvent += OnShowPerformanceReviewer;
            }

            Close();
        }

        private void OnDestroy()
        {
            if (gameTimerManager != null)
            {
                gameTimerManager.OnDayStartedEvent -= OnShowPerformanceReviewer;
            }
        }

        public void ShowAllTaskResults()
        {
            OnShowPerformanceReviewer();
        }

        public void Open()
        {
            systemParent.SetActive(true);
        }

        public void Close()
        {
            systemParent.SetActive(false);
        }

        private void OnShowPerformanceReviewer()
        {
            //Do not show the performance reviewer on the start of your first day
            if (gameTimerManager.Day == 1) return;

            //Open the performance reviewer
            Open();

            //Create and add all the cards based on the result stored in the dictionary
            foreach(var res in taskResults)
            {
                CreateCard(res.Key);
            }

        }

        private void CreateCard(GameTask _task)
        {
            var go = Instantiate(performanceCardPrefab);
            go.transform.SetParent(cardsParent);

            TaskResultSaver result = _task.GetResult;

            go.GetComponent<UIPerformanceCard>().SetTaskResult(result);

            cards.Add(_task, go);

            //Apply pressure based on the task result
            int pressurePoints = PressurePointCalculator.GetPressurePoints(result);

            PressureManager.Instance.AddPresure(pressurePoints);
        }

        private void UpdateInformation(GameTask _task)
        {
            //Get relevant card
            var performanceCard = cards.First(card => card.Key == _task).Value;

            //Update Performance information
            performanceCard.GetComponent<UIPerformanceCard>().Populate(_task.GetResult);
        }

        #endregion
    }
}
