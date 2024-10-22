using UnityEngine;

namespace DevStory.GameEventSystem
{
    [System.Serializable]
    public struct GameEventData
    {
        public int eventCode;

        public string eventName;

        [Tooltip("The day when this event be fired on")]
        [Range(1f,100f)]
        public int eventFireDay;

        [Range(0f,480f)]
        public float eventFireTime;

        public GameObject prefab;
    }

    [CreateAssetMenu(fileName = "Game Event SO", menuName = "Game Events/Create a New Event")]
    public class GameEventSO : ScriptableObject,IGameEvent
    {
        public GameEventData eventData;

        public virtual void Execute()
        {
            //Fire execute on the game event
            //Will create the Game Event in game
            Debug.Log($"Firing event code:{eventData.eventName} and at{eventData.eventFireTime}");
        }
    }
}
