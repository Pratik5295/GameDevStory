using DevStory.DialogueSystem;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DevStory.UI
{
    public class EmailManager : MonoBehaviour
    {
        public static EmailManager Instance = null;

        [SerializeField] private GameEmailScreen screen;

        [SerializeField]
        private Stack<GameEmail> emailList = new Stack<GameEmail>();

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
                emailList.Push(email);

                screen.CreateEmailCard(email);

                if (activeEmail == null)
                {
                    SetActiveEmail(email);
                }
            }
        }
        public void RemoveEmail(GameEmail email)
        {
            emailList.Pop();

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
