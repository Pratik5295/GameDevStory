using DevStory.Toaster;
using UnityEngine;

namespace DevStory.GameEventSystem
{
    [CreateAssetMenu(fileName = "Toaster Event SO", menuName = "Game Events/Toasters/Create a New Toaster Event")]
    public class ToasterEventSO : GameEventSO
    {
        public ToasterDataSO fireToasterData;

        public override void Execute()
        {
            base.Execute();

            GameObject go = new GameObject($"Toaster-{fireToasterData.name}");
            UIToaster toaster = go.AddComponent<UIToaster>();
            toaster.SetToasterData(fireToasterData,go);
        }
    }
}
