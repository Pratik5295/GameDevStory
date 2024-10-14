using DevStory.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace DevStory.UI
{
    /// <summary>
    /// This script extends the screen and represents
    /// all the communications the player would receive
    /// from the supervisors or the game
    /// </summary>
    public class GameEmailScreen : Screen
    {
        [Space(10)]
        [Header("Email Content Details")]
        [SerializeField]
        private TextMeshProUGUI emailHeader;

        [Space(10)]
        [Header("Email Display Variables")]
        public GameEmail activeEmail;
        [SerializeField] private GameObject emailCardPrefab;
        [SerializeField] private GameObject emailPrefab;

        [SerializeField] private Transform emailCardContent;
        [SerializeField] private Transform emailContent;
        private Dictionary<EmailSO,GameObject> generatedEmails
            = new Dictionary<EmailSO,GameObject>();

        [SerializeField]
        private ScrollRect threadScroll;
        private float scrollSpeed = 1.0f;


        public void CreateEmailCard(GameEmail email)
        {
            var card = Instantiate(emailCardPrefab);
            card.transform.SetParent(emailCardContent,false);

            var ui = card.GetComponent<UIEmailCard>();
            ui.Populate(email);

            //Add to dictionary
            if (!generatedEmails.ContainsKey(email.Data))
            {
                generatedEmails.Add(email.Data, card);
            }
        }

        public void RemoveEmailCard(EmailSO _data)
        {
            if (generatedEmails.ContainsKey(_data))
            {
                var obj = generatedEmails[_data];
                generatedEmails.Remove(_data);

                Destroy(obj);
            }
        }

        /// <summary>
        /// Move to manager afterwards
        /// </summary>
        public void SetActiveEmail(GameEmail _newEmail)
        {
            activeEmail = _newEmail;
            emailHeader.text = _newEmail.EmailTitle;
            DisplayNextMessage();
        }

        public void ClearThread()
        {
            if (emailContent.childCount == 0) return;

            for(int i = 0; i< emailContent.childCount; i++)
            {
                Destroy(emailContent.GetChild(i).gameObject);
            }
        }

        public void DisplayNextMessage()
        {
            var currentMessage = activeEmail.GetMessage();

            var emailDisplay = CreateNewMessage();
            emailDisplay.Populate(currentMessage, activeEmail,this);

            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(ScrollToEnd());
            }

        }

        private EmailDisplay CreateNewMessage()
        {
            var created = Instantiate(emailPrefab);
            created.transform.SetParent(emailContent.transform, false);

            return created.GetComponent<EmailDisplay>();
        }

        public void ShowNextMessage()
        {
            if (activeEmail.LastMessageShown())
            {
                
            }
            else
            {
                activeEmail.TraverseMessageCounter();
                DisplayNextMessage();
            }
        }

        private IEnumerator ScrollToEnd()
        {
            float time = 0f;
            float targetPosition = 0f; // Scroll to the bottom

            while (time < scrollSpeed)
            {
                time += Time.deltaTime;
                threadScroll.verticalNormalizedPosition = Mathf.Lerp(threadScroll.verticalNormalizedPosition, targetPosition, time / scrollSpeed);
                yield return null;
            }
        }
      }
    }
