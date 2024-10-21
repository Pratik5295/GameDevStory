using DevStory.Gameplay.GameTimer;
using DevStory.Interfaces.UI;
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
        public float Deadline;
        public float SubmissionTime;

        public TaskResultSaver(string _taskName, TaskStatus _status, float _deadline)
        {
            TaskName = _taskName;
            Status = _status;
            Deadline = _deadline;
            SubmissionTime = -1;    //-1 reflects the task wasnt submitted yet
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

                //Create card on the content
                CreateCard(_task);
            }
            else
            {
                UpdateResultValue(_task, _saver);
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

        public void UpdateResultValue(GameTask _task, TaskResultSaver _saver)
        {
            taskResults[_task] = _saver;

            //Update information on the card
            UpdateInformation(_task);
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
                gameTimerManager.OnDayEndedEvent += OnShowPerformanceReviewer;
            }

            Close();
        }

        private void OnDestroy()
        {
            if (gameTimerManager != null)
            {
                gameTimerManager.OnDayEndedEvent -= OnShowPerformanceReviewer;
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
            Open();
        }

        private void CreateCard(GameTask _task)
        {
            var go = Instantiate(performanceCardPrefab);
            go.transform.SetParent(cardsParent);

            go.GetComponent<UIPerformanceCard>().SetTaskResult(_task.GetResult);

            cards.Add(_task, go);
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
