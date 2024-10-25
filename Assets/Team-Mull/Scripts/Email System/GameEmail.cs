using DevStory.UI;
using System.Collections.Generic;
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

        [SerializeField] private EmailSO data;

        public EmailSO Data => data;

        public DialogueMessageSO[] Messages => data.Messages;

        public int MessageCount => Messages.Length;

        [SerializeField] private string emailTitle;

        public string EmailTitle => emailTitle;


        //Local cache for messages

        [Space(5)]
        [Header("Local Cache Variables")]
        [SerializeField] private bool dirty = false;

        public bool IsDirty => dirty;

        public Queue<DialogueMessageSO> localQueue = new Queue<DialogueMessageSO>();


        public void SetEmailData(EmailSO _data)
        {
            data = _data;
            lastEmailIndex = data.Messages.Length;
            emailTitle = data.EmailTitle;

            //Notify manager of new Email Data added
            EmailManager.Instance.AddEmail(this);
        }

        public bool LastMessageShown()
        {
            var currentMessageShown = data.Messages[currentEmailIndex];

            if (currentMessageShown.Type == DialogMessageType.ENDER)
            {
                return true;
            }

            return currentEmailIndex >= lastEmailIndex - 1;
        }

        public DialogueMessageSO GetMessage()
        {
            //First message was shown to the player
            dirty = true;

            var message = data.Messages[currentEmailIndex];

            //Load the queue up
            LoadQueue(message);
            return message;
        }

        public DialogueMessageSO GetNextMessage()
        {
            currentEmailIndex++;

            var message = data.Messages[currentEmailIndex];

            //Load the queue up
            LoadQueue(message);
            return message;
        }

        public void TraverseMessageCounter()
        {
            currentEmailIndex++;
        }

        /// <summary>
        /// This traversal message needs to populate the next email response based on new counter
        /// </summary>
        /// <param name="_newCounter"></param>
        public void TraverseMessageCounterTo(int _newCounter)
        {
            currentEmailIndex = _newCounter;
        }

        

        private void LoadQueue(DialogueMessageSO _message)
        {
            if (localQueue.Contains(_message)) return;

            localQueue.Enqueue(_message);
        }
    }
}
