using DevStory.Interfaces.UI;
using System;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.UI
{
    public class Screen : MonoBehaviour, IScreen
    {
        [SerializeField] 
        private ScreenState screenState = ScreenState.CLOSED;

        public ScreenState State { get { return screenState; } }

        public bool isOpened => screenState == ScreenState.OPENED;

        public Action<ScreenState> OnStateChangeEvent;

        public virtual void Close()
        {
            gameObject.SetActive(false);
            UpdateScreenState(ScreenState.CLOSED);
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
            UpdateScreenState(ScreenState.OPENED);
        }

        private void UpdateScreenState(ScreenState _state)
        {
            screenState = _state;
            OnStateChangeEvent?.Invoke(screenState);
        }
    }
}
