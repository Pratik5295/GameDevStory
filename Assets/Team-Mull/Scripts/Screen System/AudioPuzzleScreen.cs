using DevStory.Gameplay.AudioPuzzle;
using DevStory.Gameplay.Puzzles;
using DevStory.TaskSystem;
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


        public override void SetTaskOnScreen(GameTask _gameTask)
        {
            base.SetTaskOnScreen(_gameTask);
            
            //Check if puzzle is an audio puzzle
            if(puzzle.gameObject.TryGetComponent<AudioPuzzle>(out var audioPuzzle))
            {
                SetUpSliders(audioPuzzle.Wave);
                Debug.Log("Audio puzzle sliders are set");
            }

        }

        public void SetUpSliders(GameWave _wave)
        {
            foreach(UIAudioSlider slider in measurementSliders)
            {
                slider.SetGameWave(_wave);
            }
        }
    }
}
