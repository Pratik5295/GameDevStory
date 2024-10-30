using DevStory.Data;
using DevStory.Interfaces;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace DevStory.UI
{
    /// <summary>
    /// Generic UI Screen button, basic purpose is to change screens in the game
    /// Extends the IScreenChangeable interface to implement
    /// </summary>

    public class UIScreenButton : MonoBehaviour, IScreenChangeable
    {
        [SerializeField]
        private ScreenChangeData screenChangeData;

        [SerializeField]
        private TextMeshProUGUI button_text;

        [SerializeField]
        private Button button;

        public Action OnSwitchScreenEventFired;

        private void Start()
        {
        }

        private void OnDestroy()
        {
            if (button == null) return;

            button.onClick.RemoveAllListeners();
        }

        private void OnEnable()
        {
            button_text.text = screenChangeData.Message;
        }

        public void PopulateDisplay(ScreenChangeData _newData)
        {
            screenChangeData = _newData;
            button_text.text = screenChangeData.Message;

            button = GetComponent<Button>();

            button.onClick.AddListener(SwitchToNextScreen);
        }

        public void SwitchToNextScreen()
        {
            ChangeScreen(screenChangeData);

            OnSwitchScreenEventFired?.Invoke();
        }

        public void ChangeScreen(ScreenChangeData screenData)
        {
            ScreenManager.Instance.ScreenChange(screenData.OpenScreen);
        }
    }
}
