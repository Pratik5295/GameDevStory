using UnityEngine;

namespace DevStory.Toaster
{
    [System.Serializable]
    public struct ToasterData
    {
        //Message to be displayed
        public string Message;

        //Will be switched to an enum soon
        public int OpenScreen;
    }
}
