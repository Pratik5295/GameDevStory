using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.Gameplay.Puzzles
{
    public class PaintPuzzle : MonoBehaviour
    {
        [SerializeField]
        private List<PaintHolder> paintHolders = new List<PaintHolder>();

        [SerializeField]
        private Transform content;

        #region Context Menu Functions
        [ContextMenu("Populate Holders")]
        public void FindPaintHolders()
        {
            //Clear if any existing paint holders
            paintHolders.Clear();

            //Find new holders
            for(int i = 0; i < content.childCount; i++)
            {
                var holder = content.GetChild(i).GetComponent<PaintHolder>();
                paintHolders.Add(holder);
            }

            if (paintHolders.Count <= 0)
            {
                Debug.LogError("No Paint Holders were found!");
            }
            else
            {
                Debug.Log("Populating the paint holders via context menu");
            }
        }

        #endregion


        public bool CheckPuzzleValidation()
        {
            foreach (var holder in paintHolders)
            {
                if (!holder.IsValid()) return false;
            }

            return true;
        }

        public void ResetPuzzle()
        {
            foreach (var holder in paintHolders)
            {
                holder.ResetTile();
            }
        }
    }
}
