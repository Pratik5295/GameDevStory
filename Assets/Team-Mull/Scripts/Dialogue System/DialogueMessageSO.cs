using UnityEngine;

namespace DevStory.Dialogue
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
        public int CodeIdentifier;

        //The one who is speaking 
        public string Speaker;

        public string Message;

        public DialogueOption[] Options;
    }

}
