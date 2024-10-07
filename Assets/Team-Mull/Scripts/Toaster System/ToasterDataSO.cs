using UnityEngine;

namespace DevStory.Toaster
{
    [CreateAssetMenu(fileName = "Toaster SO", menuName = "Toaster System/Create a Toaster Message")]
    public class ToasterDataSO : ScriptableObject
    {
        public ToasterData data;
    }
}
