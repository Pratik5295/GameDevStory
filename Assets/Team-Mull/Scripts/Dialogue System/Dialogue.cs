using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.DialogueSystem
{
    /// <summary>
    /// The front end handler of dialogue
    /// </summary>
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private int currentMessageIndex = 0;
        private int lastMessageIndex;

        public int LastMessageIndex => lastMessageIndex;
        public int CurrentIndex => currentMessageIndex;

        [SerializeField] private DialogueSO currentDialogue;

        public DialogueMessageSO[] Messages => currentDialogue.Messages;

        private void Awake()
        {
            lastMessageIndex = currentDialogue.Messages.Length;
        }

        public bool LastMessageShown()
        {
            var currentMessageShown = currentDialogue.Messages[currentMessageIndex];

            if (currentMessageShown.Type == DialogMessageType.ENDER)
            {
                return true;
            }

            return currentMessageIndex >= lastMessageIndex - 1;
        }

        public DialogueMessageSO GetMessage()
        {
            return currentDialogue.Messages[currentMessageIndex];
        }

        public DialogueMessageSO GetNextMessage()
        {
            currentMessageIndex++;
            return currentDialogue.Messages[currentMessageIndex];
        }

        public void TraverseMessageCounter()
        {
            currentMessageIndex++;
        }

        public void TraverseMessageCounterTo(int _newCounter)
        {
            currentMessageIndex = _newCounter;
        }
    }
}
