using System;
using UnityEngine;

namespace DevStory.PressureSystem
{
    /// <summary>
    /// The singleton that will be responsible for 
    /// creating a pressure class object and 
    /// updating the pressure values. 
    /// </summary>
    /// 
    [DefaultExecutionOrder(0)]
    public class PressureManager : MonoBehaviour
    {
        public static PressureManager Instance = null;

        [SerializeField]
        private Pressure Pressure;

        public Action<float> OnPressureChangedEvent;

        public float GetMaxPressure => Pressure.MaximumPressure;
        public float GetCurrentPressure => Pressure.CurrentPressure;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            Pressure = new Pressure(0, 100);
        }

        /// <summary>
        /// Failing tasks would add on the pressure
        /// </summary>
        /// <param name="_amount"></param>
        public void AddPresure(float _amount)
        {
            Pressure.AddPressure(_amount);
            OnPressureChangedEvent?.Invoke(Pressure.CurrentPressure);
        }

        /// <summary>
        /// Stress busters and day activity changes 
        /// will update the pressure using this method
        /// </summary>
        /// <param name="_amount"></param>
        public void ReducePressure(float _amount)
        {
            Pressure.ReducePressure(_amount);
            OnPressureChangedEvent?.Invoke(Pressure.CurrentPressure);
        }

    }
}
