using UnityEngine;

namespace DevStory.GameEventSystem
{
    public struct GameEventData
    {
        [Range(0f,480f)]
        public float eventFireTime;

        public GameObject prefab;
    }

    [CreateAssetMenu(fileName = "Game Event SO", menuName = "Game Events/Create a New Event")]
    public class GameEventSO : ScriptableObject
    {
        public GameEventData eventData;
    }
}
