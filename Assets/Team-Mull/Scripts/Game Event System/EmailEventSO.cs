using DevStory.DialogueSystem;
using DevStory.Toaster;
using UnityEngine;

namespace DevStory.GameEventSystem
{
    /// <summary>
    /// This SO will be responsible for firing email request at fire time,
    /// generating appropriate Game Email object at runtime,
    /// generating toaster event at runtime
    /// and updating Email Manager about the same
    /// </summary>
    /// 

    [CreateAssetMenu(fileName = "Email Event SO",menuName = "Game Events/Emails/Create a New Email Event")]
    public class EmailEventSO : GameEventSO
    {
        public EmailSO emailData;

        public ToasterDataSO emailToasterData;

        public override void Execute()
        {
            base.Execute();

            GameObject go = new GameObject($"Email-{emailData.EmailTitle}");
            GameEmail gameEmail = go.AddComponent<GameEmail>();

            gameEmail.SetEmailData(emailData);

            //Also notify via toaster
            GameObject toast = new GameObject($"Toaster-{emailToasterData.name}");
            UIToaster toaster = toast.AddComponent<UIToaster>();
            toaster.SetToasterData(emailToasterData,toast);
        }
    }
}
