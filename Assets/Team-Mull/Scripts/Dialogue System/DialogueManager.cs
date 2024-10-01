using DevStory.Interfaces.UI;
using UnityEngine;

namespace DevStory.Dialogue
{
    /// <summary>
    /// The dialogue manager will be a singleton responsible for 
    /// changing the active dialogue, showing and hiding the dialogue screen
    /// </summary>
    public class DialogueManager : MonoBehaviour, IScreen
    {
        public static DialogueManager Instance = null;

        [SerializeField] private DialogueScreen dialogueScreen;

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

        #region IScreen interface methods
        public void Open()
        {
            dialogueScreen.gameObject.SetActive(true);
        }

        public void Close()
        {
            dialogueScreen.gameObject.SetActive(false);
        }

        #endregion
    }
}
