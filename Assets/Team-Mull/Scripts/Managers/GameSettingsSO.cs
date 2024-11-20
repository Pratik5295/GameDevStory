using UnityEngine;

namespace DevStory.Managers
{
    [System.Serializable]
    public struct WinConditionsData
    {
        public float MaximumExperienceInGame;

        public float ExperienceRequiredThreshold;

        public float StressThreshold;
    }


    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Create Game Settings")]
    public class GameSettingsSO : ScriptableObject
    {
        [Header("Day Timer Details")]
        public int FinalDay;

        [Space(10)]
        [Header("Win Conditions")]
        public WinConditionsData WinConditions;
    }
}
