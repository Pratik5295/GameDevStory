
using Unity.VisualScripting;

namespace DevStory.PressureSystem
{
    /// <summary>
    /// This class will handle all the 
    /// mathematical handling of the pressure of game.
    /// </summary>
    /// 
    [System.Serializable]
    public class Pressure
    {
        private float currentPressure;
        private float maximumPressure;

        private bool pressureMaxedOut;

        public bool PressureMaxed => pressureMaxedOut;

        public float CurrentPressure => currentPressure;

        public float MaximumPressure => maximumPressure;

        /// <summary>
        /// Pressure constructor
        /// </summary>
        public Pressure(float _currentPressure, float _maxPressure)
        {
            currentPressure = _currentPressure;
            maximumPressure = _maxPressure;
        }
       
        public void AddPressure(float _amount)
        {
            if (currentPressure + _amount >= maximumPressure)
            {
                pressureMaxedOut = true;
            }
            currentPressure += _amount;
        }

        public void ReducePressure(float _amount)
        {
            if (currentPressure == 0) return;

            currentPressure -= _amount;
            pressureMaxedOut = false;
        }
    }
}
