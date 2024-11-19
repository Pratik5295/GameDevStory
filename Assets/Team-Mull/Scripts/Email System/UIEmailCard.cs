using DevStory.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.UI
{ 
    /// <summary>
    /// This script will be attached on the email card UI
    /// </summary>
    public class UIEmailCard : MonoBehaviour
    {
        [SerializeField] private GameEmail email;

        [SerializeField]
        private TextMeshProUGUI senderNameText;

        [SerializeField]
        private TextMeshProUGUI emailSubjectText;

        [SerializeField]
        private TextMeshProUGUI emailContentText;

        [SerializeField]
        private Image senderSprite;

        [SerializeField]
        private GameObject newNotifierObject;   //This will be turned off when email is read

        public void Populate(GameEmail _email)
        {
            email = _email;

            if (email.Messages[0].Speaker != null)
            {
                senderNameText.text = _email.Messages[0].Speaker.Data.CharacterName;
                senderSprite.sprite = _email.Messages[0].Speaker.Data.CharacterSprite;
            }
            else
            {
                Debug.LogWarning("Missing Sender info on the email!", gameObject);
            }

            emailSubjectText.text = _email.EmailTitle;
            emailContentText.text = _email.Messages[0].Message;


            //Set a listener for dirty state
            email.OnEmailOpenedEvent += OnEmailOpenedHandler;


        }

        private void OnDestroy() 
        {
            if (email != null)
            {
                email.OnEmailOpenedEvent -= OnEmailOpenedHandler;
            }
        }

        private void OnEmailOpenedHandler()
        {
            newNotifierObject.SetActive(false);

            Debug.Log("Email has been opened",gameObject);
        }

        public void OnButtonClicked()
        {
            EmailManager.Instance.SetActiveEmail(email);
        }
    }
}
