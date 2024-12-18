using DevStory.VFX;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;


namespace DevStory.Gameplay.Puzzles
{
    public class PaintPalette : MonoBehaviour
    {
        [SerializeField]
        private ScaleAndReset glowImage;


        public void SetGlowColor(PuzzlePaint _paint)
        {
            if (glowImage == null) return;

            glowImage.SetNewColor(_paint);
        }
    }
}
