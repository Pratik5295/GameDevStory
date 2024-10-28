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

        [SerializeField]
        private float valueMuliplier;

        public void SetGameWave(GameWave _wave)
        {
            gameWave = _wave;
        }


        public void OnSliderValueUpdated(float _amount)
        {
            if (gameWave == null) return;

            var value = (_amount / 100) * valueMuliplier;

            gameWave.OnUpdateMeasurement(type, value);
        }


    }
}
