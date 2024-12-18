using DevStory.Managers;
using DevStory.TaskSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DevStory.UI
{
    public class TaskColumn : MonoBehaviour
    {
        [SerializeField] private Transform content;

        [SerializeField] private GameObject taskCardPrefab;

        [SerializeField] private List<GameTask> tasksAdded = new List<GameTask>();

        [Header("Audio Section")]
        [SerializeField]
        private AudioClip taskCardSfx;

        public void CreateNewTask(GameTask _gameTask)
        {
            //No need to create a new task again
            if (tasksAdded.Contains(_gameTask)) return;

            var go = Instantiate(taskCardPrefab);
            go.transform.SetParent(content.transform, false);

            PlaySfx();

            var ui = go.GetComponent<UITaskCard>();
            ui.SetTaskData(_gameTask);

            tasksAdded.Add(_gameTask);
        }

        public void ClearColumn()
        {
            tasksAdded.Clear();

            for(int i = 0; i < content.childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }

        private void PlaySfx()
        {
            if (taskCardSfx != null)
                AudioManager.Instance.PlaySFX(taskCardSfx);
        }
    }
}
