using DevStory.Toaster;
using UnityEngine;

public class UIToaster : MonoBehaviour
{
    [SerializeField] private ToasterDataSO toasterSO;

    public void SetToasterData(ToasterDataSO _data)
    {
        toasterSO = _data;

        OpenToasterTest();
    }

    public void OpenToasterTest()
    {
        ToasterManager.Instance.PopulateToasterMessage(toasterSO.data);
    }
}
