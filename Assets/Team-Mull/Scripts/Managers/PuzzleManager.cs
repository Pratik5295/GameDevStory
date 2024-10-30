using DevStory.TaskSystem;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Managers
{
    //Can move everything to task manager
    public class PuzzleManager : MonoBehaviour
    {
        public static PuzzleManager Instance = null;

        [Header("Puzzle Parent References")]

        [SerializeField]
        private GameObject paintParent;

        [SerializeField]
        private GameObject programmingParent;

        [SerializeField]
        private GameObject audioParent;


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

        public Transform GetParentReference(GameTaskData _taskData)
        {
            switch (_taskData.Type)
            {
                case TaskType.PAINT:
                    return paintParent.transform;

                case TaskType.PROGRAM:
                    return programmingParent.transform;

                case TaskType.AUDIO:
                    return audioParent.transform;
            }

            return null;
        }
    }
}
