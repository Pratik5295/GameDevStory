using DevStory.Managers;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEditorInternal;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This script will added on the performance card prefab 
    /// to populate its display
    /// </summary>
    public class UIPerformanceCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI taskTitle;
        [SerializeField] private TextMeshProUGUI taskStatus;
        [SerializeField] private TextMeshProUGUI taskDeadline;

        [SerializeField]
        private List<GameObject> priorityIndicators;

        [SerializeField]
        private TaskResultSaver result;

        public void SetTaskResult(TaskResultSaver _result)
        {
            result = _result;
            Populate(result);

        }

        public void Populate(TaskResultSaver _result)
        {
            HideAllIndicators();

            taskTitle.text = _result.TaskName;

            Tuple<string, string> submissionData = GetSubmissionTime(_result);

            taskStatus.text = $"{submissionData.Item1}";
            taskDeadline.text = $"{submissionData.Item2}";

            //Get how many to show based on priority
            int indicatorsToShow = TaskManager.Instance.GetCountFromPriority(_result.Priority);

            ShowIndicators(indicatorsToShow);
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
            for (int i = 0; i < count; i++)
            {
                priorityIndicators[i].SetActive(true);
            }
        }

        private Tuple<string,string> GetSubmissionTime(TaskResultSaver _result)
        {
            Tuple<string, string> data = null;
            if(_result.Status == TaskStatus.TODO)
            {
                //Puzzle is incomplete

                data = Tuple.Create("Incomplete", "Late");
                return data;
            }
            else if(_result.Status == TaskStatus.SUBMITTED)
            {
                string submission = string.Empty;

                if (_result.Deadline > _result.SubmissionTime)
                {
                    submission = "On Time";
                }
                else
                {
                    submission = "Late";
                }


                //Check if it was right or wrong
                string status = string.Empty;
                switch (_result.Result)
                {
                    case TaskResult.FAILURE:
                        status = "Failed";
                        break;

                    case TaskResult.COMPLETED_PAST_DEADLINE:
                        status = "Complete";
                        submission = "Late";
                        break;

                    case TaskResult.COMPLETED:
                        status = "Complete";
                        break;
                }

                data = Tuple.Create(status, submission);
            }

            return data;
        }

    }
}
