using DevStory.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    /// <summary>
    /// This script will be responsible to determine if the adjacent tiles have the same color
    /// This script will attached on all tiles/sprites that are paint holders
    /// </summary>
    /// 
    [RequireComponent(typeof(PaintTile))]
    public class PaintHolder : MonoBehaviour,IHoldable
    {
        [SerializeField]
        private List<PaintTile> paintHolders = new List<PaintTile>();

        [SerializeField] private PaintTile self;
        [SerializeField] private PuzzlePaint selfPaintValue;  

        private void Start()
        {
            self = GetComponent<PaintTile>();

            RegisterEvents();
        }

        private void OnDestroy()
        {
            UnregisterEvents();
        }

        #region Event Handling
        private void RegisterEvents()
        {
            self.OnPaintChangedEvent += OnSelfPaintChangeHandler;
        }

        private void UnregisterEvents()
        {
            self.OnPaintChangedEvent -= OnSelfPaintChangeHandler;
        }

        #endregion


        private void OnSelfPaintChangeHandler(PuzzlePaint _paint)
        {
            //Self value has changed
            selfPaintValue = _paint;
        }

        public void PiecePlaced(Piece piece)
        {
            //Not implemented Yet, check later if required
        }

        public void PieceRemoved()
        {
            //Not implemented Yet
        }
    }
}
