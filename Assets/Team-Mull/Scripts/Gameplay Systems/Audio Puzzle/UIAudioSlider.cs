using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.AudioPuzzle
{
    public class UIAudioSlider : MonoBehaviour
    {
        //Type of measurement to update on
        [SerializeField]
        private AudioMeasurements type;

        //Reference to game wave
        [SerializeField]
        private GameWave gameWave;

        public GameWave GameWave => gameWave;

        public void SetGameWave(GameWave _wave)
        {
            gameWave = _wave;
        }


        public void OnSliderValueUpdated(float _amount)
        {
            if (gameWave == null) return;

            gameWave.OnUpdateMeasurement(type, _amount);
        }


    }
}
