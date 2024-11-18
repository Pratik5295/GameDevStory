using DG.Tweening;
using DevStory.Data;
using DevStory.Interfaces.UI;
using DevStory.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DevStory.Managers;

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


        [SerializeField]
        private float hideY;

        [SerializeField]
        private float showY;

        public GameObject toasterObject;    //The toaster object that got created to populate this


        [SerializeField]
        private AudioClip toasterSfx;

        [SerializeField]
        private AudioClip buttonClickSfx;

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
                PlaySfx(buttonClickSfx);
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
                PlaySfx(buttonClickSfx);
            });

            Open();
        }

        public void Open()
        {
            toasterDisplay.SetActive(true);
            Show();

        }

        public void Close()
        {
            Hide();

            if(toasterObject != null)
            {
                Destroy(toasterObject);
            }
        }


        //For Do Tweening
        private void Hide()
        {
            transform.DOMoveY(hideY, 0.5f, false);
        }

        private void Show()
        {
            transform.DOMoveY(showY, 0.5f, false);
            PlaySfx(toasterSfx);
        }

        private void PlaySfx(AudioClip _clip)
        {
            if(_clip != null)
                AudioManager.Instance.PlaySFX(_clip);
        }
    }
}
