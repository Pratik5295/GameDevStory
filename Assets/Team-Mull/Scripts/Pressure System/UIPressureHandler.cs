using UnityEngine;
using UnityEngine.UI;

namespace DevStory.PressureSystem
{
    /// <summary>
    /// The UI representation of the pressure system
    /// </summary>
    /// 
    [DefaultExecutionOrder(1)]
    public class UIPressureHandler : MonoBehaviour
    {
        [SerializeField]
        private PressureManager pressureManager;

        [SerializeField]
        private Slider pressureSlider;

        private void Start()
        {
            pressureManager = PressureManager.Instance;

            if (pressureManager != null)
            {
                pressureManager.OnPressureChangedEvent +=
                    OnPressureChangedEventHandler;
            }

            //Handle UI reference 
            pressureSlider = GetComponent<Slider>();
            OnPressureChangedEventHandler(pressureManager.GetCurrentPressure);

        }
        private void OnDestroy()
        {
            if (pressureManager != null)
            {
                pressureManager.OnPressureChangedEvent -=
                    OnPressureChangedEventHandler;
            }
        }

        private void OnPressureChangedEventHandler(float _newPressure)
        {
            UpdatePressureSlider(_newPressure);
        }

        private void UpdatePressureSlider(float _currentPressure)
        {
            float maxPressure = pressureManager.GetMaxPressure;

            var pressurePercentage =
                _currentPressure/maxPressure;

            pressureSlider.value = pressurePercentage;
        }
    }
}
