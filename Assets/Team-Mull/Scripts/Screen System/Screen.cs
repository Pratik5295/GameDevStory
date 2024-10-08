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

        [SerializeField] private GameObject content;

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

        /// <summary>
        /// The task puzzles will set the content at runtime
        /// </summary>
        /// <param name="_content"></param>
        public void SetContent(GameObject _content)
        {
            content = _content;
        }

        private void OnEnable()
        {
            if (content == null) return;
            //Check for any puzzles available to display
            content.SetActive(true);
        }

        private void OnDisable()
        {
            if (content == null) return;
            content.SetActive(false);
        }
    }
}
