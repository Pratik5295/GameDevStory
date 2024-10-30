using DevStory.Gameplay.AudioPuzzle;
using System.Collections.Generic;
using UnityEngine;

namespace DevStory.UI
{
    /// <summary>
    /// This scripts extends the base puzzle screen class
    /// holds the functionality required for audio puzzle screen
    /// </summary>
    public class AudioPuzzleScreen : PuzzleScreen
    {
        [SerializeField]
        private List<UIAudioSlider> measurementSliders;

        public void SetUpSliders(GameWave _wave)
        {
            foreach(UIAudioSlider slider in measurementSliders)
            {
                slider.SetGameWave(_wave);
            }
        }
    }
}
