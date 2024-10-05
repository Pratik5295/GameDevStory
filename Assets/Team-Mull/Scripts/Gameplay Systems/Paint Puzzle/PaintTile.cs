using DevStory.Interfaces;
using DevStory.Utility;
using System;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    /// <summary>
    /// This script will attached on the paint holding pieces
    /// 
    /// 
    /// </summary>
    public class PaintTile : MonoBehaviour,IColorChangeable
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private PuzzlePaint heldPaint;

        public PuzzlePaint HoldingPaint => heldPaint;
        public Action<PuzzlePaint> OnPaintChangedEvent;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void ChangeColor(PuzzlePaint _newPaint)
        {
            spriteRenderer.color = ColorCoder.GetColor(_newPaint);

            OnPaintChanged(_newPaint);
        }

        private void OnPaintChanged(PuzzlePaint _newPaint)
        {
            heldPaint = _newPaint;
            OnPaintChangedEvent?.Invoke(heldPaint);
        }

    }
}
