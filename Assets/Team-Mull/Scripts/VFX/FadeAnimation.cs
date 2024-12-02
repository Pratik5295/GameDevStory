using DG.Tweening;
using UnityEngine;

namespace DevStory.VFX
{

    public class FadeAnimation : MonoBehaviour
    {
        // Reference to the UI element (e.g., an Image or Text)
        public CanvasGroup canvasGroup; // CanvasGroup is needed for fade-in/fade-out

        // Start the FadeIn and FadeOut Sequence
        void Start()
        {
          
        }

        public void FadeInAndOut()
        {
            // Fade In
            canvasGroup.DOFade(1, 1f)  // Fade to 1 (fully visible) in 1 second
                .OnComplete(() =>
                {
                    // After fade-in is complete, wait for a moment, then fade out
                    canvasGroup.DOFade(0, 1f)  // Fade to 0 (fully transparent) in 1 second
                        .SetDelay(2f); // Delay before fade-out
                });
        }

        public void FadeIn()
        {
            canvasGroup.DOFade(1, 3f);
        }

        public void FadeOut()
        {
            canvasGroup.DOFade(0, 2f);
        }
    }
}
