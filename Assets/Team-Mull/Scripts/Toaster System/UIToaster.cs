using DevStory.Toaster;
using UnityEngine;

public class UIToaster : MonoBehaviour
{
    [SerializeField] private ToasterDataSO toasterSO;

    public void OpenToasterTest()
    {
        ToasterManager.Instance.PopulateToasterMessage(toasterSO.data);
    }
}
