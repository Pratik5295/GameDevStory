using DevStory.Toaster;
using UnityEngine;

public class UIToaster : MonoBehaviour
{
    ToasterData data;
    private void Start()
    {
        data = new ToasterData()
        {
            Message = "Testing toaster system",
            OpenScreen = 1
        };
    }

    public void OpenToasterTest()
    {
        ToasterManager.Instance.PopulateToasterMessage(data);
    }
}
