using UnityEngine;

namespace DevStory.DialogueSystem
{
    /// <summary>
    /// The scriptable object script to handle the data of dialogues via messages
    /// </summary>
    [CreateAssetMenu(fileName = "Game Email", menuName = "Email System/Create a New Game Email")]
    public class EmailSO : ScriptableObject
    {
        public string EmailTitle;

        public DialogueMessageSO[] Messages;
    }
}
