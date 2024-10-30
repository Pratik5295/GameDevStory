using DevStory.Data;
using DevStory.Interfaces.UI;
using DevStory.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.Toaster
{
    /// <summary>
    /// Toaster singleton to manage, show, hide toaster and to populate messages
    /// on the toaster
    /// </summary>
    public class ToasterManager : MonoBehaviour,IScreen
    {
        public static ToasterManager Instance = null;

        [SerializeField] private ScreenChangeData data;
        [SerializeField] private GameObject toasterDisplay;

        [Space(5)]
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI toasterText;

        [SerializeField] private Button ChangeScreenButton;
        [SerializeField] private Button CloseButton;

        public GameObject toasterObject;    //The toaster object that got created to populate this

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Close();
            CloseButton.onClick.AddListener(() =>
            {
                Close();
            });
        }

        public void PopulateToasterMessage(ScreenChangeData _data,GameObject _object)
        {
            toasterObject = _object;
            toasterText.text = _data.Message;

            ChangeScreenButton.onClick.AddListener(() =>
            {
                ScreenManager.Instance.ScreenChange(_data.OpenScreen);

                //Close the toaster after the activity is opened
                Close();
            });

            Open();
        }

        public void Open()
        {
            toasterDisplay.SetActive(true);

        }

        public void Close()
        {
            toasterDisplay.SetActive(false);

            if(toasterObject != null)
            {
                Destroy(toasterObject);
            }
        }
    }
}
