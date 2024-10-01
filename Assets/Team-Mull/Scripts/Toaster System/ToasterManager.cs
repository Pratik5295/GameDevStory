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

        [SerializeField] private ToasterData data;
        [SerializeField] private GameObject toasterDisplay;

        [Space(5)]
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI toasterText;

        [SerializeField] private Button ChangeScreenButton;
        [SerializeField] private Button CloseButton;

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

        public void PopulateToasterMessage(ToasterData _data)
        {
            toasterText.text = _data.Message;

            ChangeScreenButton.onClick.AddListener(() =>
            {
                ScreenManager.Instance.OnChangeActiveScreen(_data.OpenScreen);
            });
        }

        public void Open()
        {
            toasterDisplay.SetActive(true); 
        }

        public void Close()
        {
            toasterDisplay.SetActive(false);
        }
    }
}
