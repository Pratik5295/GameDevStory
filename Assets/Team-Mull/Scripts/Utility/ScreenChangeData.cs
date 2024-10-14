using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Data
{
    [System.Serializable]
    public struct ScreenChangeData
    {
        //Message to be displayed
        public string Message;

        //Will be switched to an enum soon
        public GameScreens OpenScreen;
    }
}


