using UnityEngine;

namespace DevStory.Dialogue
{
    /// <summary>
    /// The scriptable object script to handle the data of dialogues via messages
    /// </summary>
    [CreateAssetMenu(fileName = "Dialogue",menuName = "Dialogue System/Create a New Dialogue")]
    public class DialogueSO:ScriptableObject
    {
        public DialogueMessageSO[] Messages;
    }
}
