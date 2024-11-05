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

          
        }

        public void OnButtonClicked()
        {
            EmailManager.Instance.SetActiveEmail(email);
        }
    }
}
