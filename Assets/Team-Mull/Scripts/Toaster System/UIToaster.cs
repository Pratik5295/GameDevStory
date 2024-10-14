using DevStory.Toaster;
using UnityEngine;

public class UIToaster : MonoBehaviour
{
    [SerializeField] private ToasterDataSO toasterSO;
    [SerializeField] private GameObject associatedObject;

    public void SetToasterData(ToasterDataSO _data,GameObject _object)
    {
        toasterSO = _data;
        associatedObject = _object;

        OpenToaster();
    }

    public void OpenToaster()
    {
        ToasterManager.Instance.PopulateToasterMessage(toasterSO.data, associatedObject);
    }
}
