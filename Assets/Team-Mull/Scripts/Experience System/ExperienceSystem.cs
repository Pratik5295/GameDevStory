using System;
using UnityEngine;

namespace DevStory.TaskSystem
{
    public class ExperienceSystem : MonoBehaviour
    {
        [SerializeField]
        private float currentXp = 0;

        public float CurrentXP => currentXp;

        public Action<float, float> OnExperienceGainedEvent;

        public void AddExp(float _xp)
        {
            currentXp += _xp;

            //Fires an event with gained xp and total current xp
            OnExperienceGainedEvent?.Invoke(_xp, currentXp);
        }
    }
}
