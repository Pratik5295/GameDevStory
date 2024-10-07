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
        public string Speaker;

        public string Message;

        public DialogueOption[] Options;

        public DialogMessageType Type;
    }

}
