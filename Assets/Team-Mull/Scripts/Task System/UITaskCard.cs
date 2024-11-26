using DevStory.Managers;
using DevStory.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This script will represent the task's values into the UI
    /// It will be used on the card
    /// </summary>


    public class UITaskCard : MonoBehaviour
    {
        [SerializeField] private GameTaskData taskData;

        [SerializeField] private GameTask gameTask;

        [Space(10)]
        [Header("Task Card UI References")]
        [SerializeField] private TextMeshProUGUI taskTitle;

        [SerializeField]
        private List<GameObject> priorityIndicators;

        public void SetTaskData(GameTask _gameTask)
        {
            gameTask = _gameTask;
            taskData = gameTask.GetData.TaskData;

            PopulateTaskData();
        }

        private void PopulateTaskData()
        {
            //Hide all indicators
            HideAllIndicators();

            taskTitle.text = taskData.TaskName;

            //Get how many to show based on priority
            int indicatorsToShow = TaskManager.Instance.GetCountFromPriority(taskData.Priority);

            ShowIndicators(indicatorsToShow);
        }

        public void OnTaskButtonClicked()
        {
            Debug.Log("Loading task on the dialog");
            TaskManager.Instance.OpenTaskDialogBox(gameTask);
        }

        private void HideAllIndicators()
        {
            foreach (GameObject indicator in priorityIndicators)
            {
                indicator.SetActive(false);
            }
        }

        private void ShowIndicators(int count)
        {
            for(int i = 0; i< count; i++)
            {
                priorityIndicators[i].SetActive(true);
            }
        }

       
    }
}
