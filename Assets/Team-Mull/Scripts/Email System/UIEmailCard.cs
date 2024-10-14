using DevStory.DialogueSystem;
using TMPro;
using UnityEngine;

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

        public void Populate(GameEmail _email)
        {
            email = _email;
            senderNameText.text = _email.Messages[0].Speaker;
            emailSubjectText.text = _email.EmailTitle;
            emailContentText.text = _email.Messages[0].Message;
        }

        public void OnButtonClicked()
        {
            EmailManager.Instance.SetActiveEmail(email);
        }
    }
}
