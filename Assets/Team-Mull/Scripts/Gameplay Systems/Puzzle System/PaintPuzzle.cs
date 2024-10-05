using UnityEngine;
using System.Collections.Generic;

namespace DevStory.Gameplay.Puzzles
{
    public class PaintPuzzle : MonoBehaviour
    {
        [SerializeField]
        private List<PaintHolder> paintHolders = new List<PaintHolder>();

        public void SubmitPuzzleCheck()
        {
            Debug.Log($"Result is: {CheckPuzzleValidation()}");
        }

        public bool CheckPuzzleValidation()
        {
            foreach (var holder in paintHolders)
            {
                if (!holder.IsValid()) return false;
            }

            return true;
        }
    }
}
