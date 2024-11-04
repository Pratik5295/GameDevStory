using System.Collections.Generic;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    public class IteratorPuzzle : Puzzle
    {
        [SerializeField]
        [Tooltip("Add iterator puzzles only")]
        private Transform contentHolder;

        [SerializeField]
        private List<IteratorHolder> puzzleHolders = new List<IteratorHolder>();


        [SerializeField] private int solvedPuzzlePieces;

        [ContextMenu("Setup Puzzle Placers")]
        public void PopulatePuzzlePieces()
        {
            if (contentHolder == null)
            {
                contentHolder = gameObject.transform.GetChild(0);
            }

            if(contentHolder.childCount == 0)
            {
                Debug.LogWarning("Iterator Puzzle Holders are missing", gameObject);
                return;
            }

           for(int i = 0; i < contentHolder.childCount; i++)
           {
                var go = contentHolder.GetChild(i).gameObject;
                if(go.TryGetComponent<IteratorHolder>(out var holder))
                {
                    puzzleHolders.Add(holder);
                }
           }
        }


        protected override void Start()
        {
            if(puzzleHolders.Count == 0)
            {
                //Force populate all the helpers
                PopulatePuzzlePieces();

                if (puzzleHolders.Count == 0)
                {
                    Debug.LogWarning("Iterator Puzzle Holders are missing", gameObject);
                    return;
                }
            }

            RegisterPuzzleHolderEvent();
        }


        private void RegisterPuzzleHolderEvent()
        {
            foreach (var holder in puzzleHolders)
            {
                holder.OnResponseChangedEvent.AddListener(ListenToPuzzleChanges);
            }
        }

        private void OnDestroy()
        {
            foreach (var holder in puzzleHolders)
            {
                holder.OnResponseChangedEvent.RemoveAllListeners();
            }
        }


        private void ListenToPuzzleChanges(PuzzlePieceResponse _receivedResponse)
        {
            if (_receivedResponse == PuzzlePieceResponse.SUCCESS)
            {
                solvedPuzzlePieces++;

                //Remove it later, as we would be using Puzzle Submit buttons
                ValidityCheck();
            }
            else
            {
                if (solvedPuzzlePieces > 0)
                    solvedPuzzlePieces--;
            }
        }

        public override bool ValidityCheck()
        {
            if (solvedPuzzlePieces == puzzleHolders.Count)
            {
                OnPuzzleSolvedEvent?.Invoke();
                return true;
            }

            return false;
        }
    }
}
