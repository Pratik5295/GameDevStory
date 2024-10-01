namespace DevStory.Dialogue
{

    [System.Serializable]
    public class DialogueOption
    {
        public string optionMessage;

        public int nextMessageIndex;
    }


    [System.Serializable]
    public class DialogueMessage
    {
        //The one who is speaking 
        public string Speaker;

        public string Message;

        public DialogueOption[] Options;
    }
}
