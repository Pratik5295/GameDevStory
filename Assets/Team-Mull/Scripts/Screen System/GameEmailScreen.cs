using DevStory.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [SerializeField] private Transform emailThreadContent;
        private Dictionary<EmailSO,GameObject> generatedEmails
            = new Dictionary<EmailSO,GameObject>();

        [SerializeField]
        private ScrollRect threadScroll;
        private float scrollSpeed = 1.0f;

        [Space(5)]
        [Header("Email Card Holder Content Reference")]
        [SerializeField]
        private GameObject emailHolderContent;

        private void Start()
        {
            if (emailHolderContent == null) return;
            emailHolderContent.SetActive(false);    
        }


        public void CreateEmailCard(GameEmail email)
        {
            var card = Instantiate(emailCardPrefab);
            card.transform.SetParent(emailCardContent,false);
            card.transform.SetAsFirstSibling();

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

            //Activate the email holder content
            emailHolderContent.SetActive(activeEmail != null);

            //Check if the queue has any data in the local cache
            if (activeEmail.IsDirty)
            {
                LoadEmailCache();
            }
            else
            {
                //Display new message only if this conversation was never opened
                DisplayNextMessage();
            }
        }

        public void ClearThread()
        {
            if (emailThreadContent.childCount == 0) return;

            for(int i = 0; i< emailThreadContent.childCount; i++)
            {
                Destroy(emailThreadContent.GetChild(i).gameObject);
            }
        }

        public void DisplayNextMessage()
        {
            var currentMessage = activeEmail.GetMessage();

            var emailDisplay = CreateNewMessage();
            emailDisplay.Populate(currentMessage, activeEmail,this);


            if (gameObject.activeInHierarchy)
            {
                int currentMessageShown = activeEmail.CurrentIndex;

                Debug.Log($"Pratik count: {currentMessageShown}");
                if (currentMessageShown > 0)
                {
                    StartCoroutine(ScrollToEnd());
                }
            }

            Canvas.ForceUpdateCanvases();

        }

        private EmailDisplay CreateNewMessage()
        {
            var created = Instantiate(emailPrefab);
            created.transform.SetParent(emailThreadContent.transform, false);

           

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

        private void LoadEmailCache()
        {
            //Displaying all the messages except the last one

            for(int i = 0; i < activeEmail.localQueue.Count - 1; i++)
            {
                var message = activeEmail.localQueue.ElementAt(i);
                var emailDisplay = CreateNewMessage();
                emailDisplay.PopulateWithoutTraverse(message, activeEmail, this);

                //Scroll to the bottom
                //threadScroll.verticalNormalizedPosition = 0f;
            }

            //Getting the last message
            var lastMessage = activeEmail.localQueue.Last();

            //Displaying last message with options if it has options
            var lastEmailDisplay = CreateNewMessage();
            lastEmailDisplay.Populate(lastMessage, activeEmail, this);

            int numberOfMessages = emailThreadContent.transform.childCount;
           

            threadScroll.verticalNormalizedPosition = 1f;
        }
      }
    }
