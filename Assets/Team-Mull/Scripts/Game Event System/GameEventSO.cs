using UnityEngine;

namespace DevStory.GameEventSystem
{
    [System.Serializable]
    public struct GameEventData
    {
        public int eventCode;

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
