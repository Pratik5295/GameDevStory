using System.Collections.Generic;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.UI
{
    /// <summary>
    /// The singleton instance for all the screens in the game
    /// Functionality: Switch and turn of screens that are not in use
    /// </summary>

    [DefaultExecutionOrder(0)]
    public class ScreenManager : MonoBehaviour
    {
        public static ScreenManager Instance = null;

        [SerializeField]
        private List<Screen> gameScreens = new List<Screen>();

        [SerializeField]
        private Screen activeScreen;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (gameScreens.Count == 0) return;

            activeScreen = gameScreens[0];
            activeScreen.Open();
        }

        public void OnChangeActiveScreen(GameScreens _value)
        {
            int screenValue = (int)_value;
            var screen = gameScreens[screenValue];

            //Close open screen
            activeScreen.Close();

            //Set new screen active
            activeScreen = screen;

            //Open new active screen
            activeScreen.Open();
            
        }

        public Screen GetScreen(GameScreens _value)
        {
            int screenValue = (int)_value;
            var screen = gameScreens[screenValue];
            return screen;
        }
    }
}
