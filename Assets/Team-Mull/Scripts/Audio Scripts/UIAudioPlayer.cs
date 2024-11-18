using DevStory.Managers;
using UnityEngine;

namespace DevStory.Audio
{
    public class UIAudioPlayer : MonoBehaviour
    {

        [SerializeField]
        private AudioClip clip;


        public void PlaySfx()
        {
            if (clip != null)
            {
                AudioManager.Instance.PlaySFX(clip);
            }
        }
    }
}
