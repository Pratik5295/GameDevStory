using System;
using UnityEngine;

namespace DevStory.TaskSystem
{
    public class ExperienceSystem : MonoBehaviour
    {
        [SerializeField]
        private int currentXp = 0;

        public int CurrentXP => currentXp;

        public Action<int, int> OnExperienceGainedEvent;

        public void AddExp(int _xp)
        {
            currentXp += _xp;

            //Fires an event with gained xp and total current xp
            OnExperienceGainedEvent?.Invoke(_xp, currentXp);
        }
    }
}
