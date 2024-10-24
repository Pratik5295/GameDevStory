using DevStory.Interfaces.UI;
using UnityEngine;
using UnityEngine.UI;

public class MullTestingHelper : MonoBehaviour,IScreen
{
    [SerializeField] private GameObject testingButtonsParent;

    [SerializeField] private bool isShowing = false;

    [SerializeField] private Button button;

    private void Start()
    {
        Close();

        button = GetComponent<Button>();    
        button.onClick.AddListener(Toggle);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    public void Close()
    {
        testingButtonsParent.SetActive(false);
        isShowing = false;
    }

    public void Open()
    {
        testingButtonsParent.SetActive(true);
        isShowing = true;
    }

    public void OnQuitGameButtonClicked()
    {
        Application.Quit();
    }

    private void Toggle()
    {
        if (isShowing)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
