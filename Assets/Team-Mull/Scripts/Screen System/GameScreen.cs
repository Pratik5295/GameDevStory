using DevStory.Managers;
using UnityEngine;

namespace DevStory.UI
{
    /// <summary>
    /// This extends the base class Screen to build the UI Screen
    /// class.
    /// It will translate to the main or starting screen of the game
    /// 
    /// </summary>
    public class GameScreen : Screen
    {
        [SerializeField]
        private AudioClip onGameScreenSfx;

        public override void Open()
        {
            base.Open();
            PlayBackgroundSFX();
        }

        private void PlayBackgroundSFX()
        {
            if (onGameScreenSfx != null)
            {
                AudioManager.Instance.PlayBackgroundMusic(onGameScreenSfx);
            }
        }
    }
}

