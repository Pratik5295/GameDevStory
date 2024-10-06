using UnityEngine;
using System.Collections.Generic;
using static MetaConstants.EnumManager.EnumManager;
using UnityEngine.Events;

namespace DevStory.Gameplay.Puzzles
{
    public class Puzzle : MonoBehaviour
    {
        [SerializeField] private List<Holder> puzzleHolders = new List<Holder>();

        [SerializeField] private PuzzleStatus currentPuzzleStatus;

        [SerializeField] private int solvedPuzzlePieces;

        public UnityEvent OnPuzzleSolvedEvent;

        private void Start()
        {
            RegisterPuzzleHolderEvent();
        }

        private void RegisterPuzzleHolderEvent()
        {
            foreach(var holder in puzzleHolders)
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
            if(_receivedResponse == PuzzlePieceResponse.SUCCESS)
            {
                solvedPuzzlePieces++;

                //Remove it later, as we would be using Puzzle Submit buttons
                ValidityCheck();
            }
            else
            {
                if(solvedPuzzlePieces > 0)
                    solvedPuzzlePieces--;
            }
        }

        public bool ValidityCheck()
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
