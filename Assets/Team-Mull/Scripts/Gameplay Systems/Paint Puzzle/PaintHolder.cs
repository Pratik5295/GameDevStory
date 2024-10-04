using DevStory.Interfaces;
using DevStory.Utility;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    /// <summary>
    /// This script will attached on the paint holding pieces
    /// 
    /// 
    /// </summary>
    public class PaintHolder : MonoBehaviour,IColorChangeable, IHoldable
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void ChangeColor(PuzzlePaint _newPaint)
        {
            spriteRenderer.color = ColorCoder.GetColor(_newPaint);
        }

        public void PiecePlaced(Piece piece)
        {

        }

        public void PieceRemoved()
        {

        }
    }
}
