using DevStory.Interfaces;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    /// <summary>
    /// This script will be attached on the water pieces
    /// 
    /// </summary>
    public class ColorPiece : Piece
    {
        [SerializeField] private PuzzlePaint Paint;


        public override void Drop()
        {
            if (collidedWith == null) return;

            var paintHolder =
                collidedWith.gameObject.GetComponent<IColorChangeable>();

            paintHolder.ChangeColor(Paint);

            ForceBackToOriginalPosition();
        }
    }
}
