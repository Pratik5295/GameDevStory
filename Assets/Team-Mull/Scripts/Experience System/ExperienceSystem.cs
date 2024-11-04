using UnityEngine;

namespace DevStory.TaskSystem
{
    public class ExperienceSystem : MonoBehaviour
    {
        [SerializeField]
        private int currentXp = 0;

        public int CurrentXP => currentXp;

        public void AddExp(int _xp)
        {
            currentXp += _xp;
        }
    }
}
