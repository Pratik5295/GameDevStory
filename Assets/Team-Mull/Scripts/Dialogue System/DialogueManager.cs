using DevStory.Interfaces.UI;
using UnityEngine;

namespace DevStory.DialogueSystem
{
    /// <summary>
    /// The dialogue manager will be a singleton responsible for 
    /// changing the active dialogue, showing and hiding the dialogue screen
    /// </summary>
    public class DialogueManager : MonoBehaviour, IScreen
    {
        public static DialogueManager Instance = null;

        [SerializeField] private DialogueScreen dialogueScreen;

        [SerializeField] private GameEmail currentDialogue;

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

        public void SetActiveDialog(GameEmail _newDialogue)
        {
            currentDialogue = _newDialogue;
            dialogueScreen.SetActiveDialogue(currentDialogue);

            Open();
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
