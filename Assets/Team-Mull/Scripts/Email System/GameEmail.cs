using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.DialogueSystem
{
    /// <summary>
    /// The front end handler of dialogue
    /// </summary>
    public class GameEmail : MonoBehaviour
    {
        [SerializeField] private int currentEmailIndex = 0;
        private int lastEmailIndex;

        public int LastMessageIndex => lastEmailIndex;
        public int CurrentIndex => currentEmailIndex;

        [SerializeField] private EmailSO currentEmail;

        public DialogueMessageSO[] Messages => currentEmail.Messages;

        [SerializeField] private string emailTitle;

        public string EmailTitle => emailTitle; 

        private void Awake()
        {
            lastEmailIndex = currentEmail.Messages.Length;
        }

        private void Start()
        {
            emailTitle = currentEmail.EmailTitle;
        }

        public bool LastMessageShown()
        {
            var currentMessageShown = currentEmail.Messages[currentEmailIndex];

            if (currentMessageShown.Type == DialogMessageType.ENDER)
            {
                return true;
            }

            return currentEmailIndex >= lastEmailIndex - 1;
        }

        public DialogueMessageSO GetMessage()
        {
            return currentEmail.Messages[currentEmailIndex];
        }

        public DialogueMessageSO GetNextMessage()
        {
            currentEmailIndex++;
            return currentEmail.Messages[currentEmailIndex];
        }

        public void TraverseMessageCounter()
        {
            currentEmailIndex++;
        }

        public void TraverseMessageCounterTo(int _newCounter)
        {
            currentEmailIndex = _newCounter;
        }
    }
}
