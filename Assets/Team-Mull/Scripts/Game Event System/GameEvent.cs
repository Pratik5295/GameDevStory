using System;
using UnityEngine;

namespace DevStory.GameEventSystem
{
    public class GameEvent : MonoBehaviour, IGameEvent
    {
        public Action OnEventCompleted;

        public void Execute()
        {
            OnEventCompleted?.Invoke();
        }
    }
}
