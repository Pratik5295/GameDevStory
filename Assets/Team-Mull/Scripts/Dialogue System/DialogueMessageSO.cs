using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.DialogueSystem
{

    [System.Serializable]
    public class DialogueOption
    {
        public string optionMessage;

        public int nextMessageIndex;
    }


    [System.Serializable]
    [CreateAssetMenu(fileName = "Dialogue Message", menuName = "Dialogue System/Create a Dialogue Message")]
    public class DialogueMessageSO: ScriptableObject
    {
        //The one who is speaking 
        public CharacterDataSO Speaker;

        [TextArea(3,12)]
        public string Message;

        public DialogueOption[] Options;

        public DialogMessageType Type;

        public bool hasTask = false;

        [Tooltip("Only being used in the email system for now")]
        [ShowIf("Type",DialogMessageType.DEFAULT)]
        public int nextIndex;

        [ShowIf("Type",DialogMessageType.SCAM)]
        public int skipTime;
    }

}
