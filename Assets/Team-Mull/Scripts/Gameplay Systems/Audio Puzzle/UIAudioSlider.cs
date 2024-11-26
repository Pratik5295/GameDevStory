using UnityEngine;
using UnityEngine.UI;
using static MetaConstants.EnumManager.EnumManager;
using static UnityEngine.Rendering.DebugUI;

namespace DevStory.Gameplay.AudioPuzzle
{
    public class UIAudioSlider : MonoBehaviour
    {
        [SerializeField]
        private Slider Slider;

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

        public void ResetSlider()
        {
            Slider.value = 0;

            if (gameWave == null) return;
            gameWave.OnUpdateMeasurement(type, 0);
        }


    }
}
