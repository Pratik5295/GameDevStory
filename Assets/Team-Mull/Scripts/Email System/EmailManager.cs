using DevStory.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DevStory.UI
{
    public class EmailManager : MonoBehaviour
    {
        public static EmailManager Instance = null;

        [SerializeField] private GameEmailScreen screen;

        [SerializeField]
        private List<GameEmail> emailList = new List<GameEmail>();

        [SerializeField] private GameEmail activeEmail;

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

        public void AddEmail(GameEmail email)
        {
            if (!emailList.Contains(email))
            {
                emailList.Add(email);

                if(activeEmail == null)
                {
                    SetActiveEmail(email);
                }

                screen.CreateEmailCard(email);
            }
        }
        public void RemoveEmail(GameEmail email)
        {
            if (emailList.Contains(email))
            {
                emailList.Remove(email);
            }

            screen.RemoveEmailCard(email.Data);
        }

        public void ClearList()
        {
            emailList.Clear();
            screen.ClearThread();
        }

        public void SetActiveEmail(GameEmail email)
        {
            activeEmail = email;

            //Clear any messages that exist
            screen.ClearThread();

            //Set active email
            screen.SetActiveEmail(email);
        }

    }
}
