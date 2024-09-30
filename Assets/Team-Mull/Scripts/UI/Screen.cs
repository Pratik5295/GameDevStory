using DevStory.Interfaces.UI;
using System;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

public class Screen : MonoBehaviour, IScreen
{
    [SerializeField] private ScreenState screenState;

    public ScreenState State { get { return screenState; } }

    public bool isOpened => screenState == ScreenState.OPENED;

    public Action<ScreenState> OnStateChangeEvent;

    public void Close()
    {
        UpdateScreenState(ScreenState.CLOSED);
    }

    public void Open()
    {
        UpdateScreenState(ScreenState.OPENED);
    }

    private void UpdateScreenState(ScreenState _state)
    {
        screenState = _state;
        OnStateChangeEvent?.Invoke(screenState);
    }
}
