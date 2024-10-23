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
            //Force back to original position in 0.2f
            //Invoke("ForceBackToOriginalPosition",0.2f);

            ForceBackToOriginalPosition();

            if (collidedWith == null) return;

            var paintHolder =
                collidedWith.gameObject.GetComponent<IColorChangeable>();

            paintHolder.ChangeColor(Paint);
        }
    }
}
