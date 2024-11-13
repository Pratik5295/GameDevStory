using DevStory.Gameplay.DragDrop;
using DevStory.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace DevStory.Gameplay.Puzzles
{
    public class IteratorPiece : Piece
    {
        [SerializeField]
        private List<IteratorClicker> iterators = new List<IteratorClicker>();

        [SerializeField]
        private bool iteratorsSolved = false;

        public bool GetIteratorsSolvedResult => iteratorsSolved;

        private void Start()
        {
            RegisterEventHandlers();
        }

        private void OnDestroy()
        {
            UnregisterEventHandlers();
        }

        private void RegisterEventHandlers()
        {
            foreach(var iterator in iterators)
            {
                iterator.OnClickerValueUpdated += OnClickerValueUpdatedHandler;
            }
        }

        private void UnregisterEventHandlers()
        {
            foreach (var iterator in iterators)
            {
                iterator.OnClickerValueUpdated -= OnClickerValueUpdatedHandler;
            }
        }


        public override void Drop()
        {
            CheckForRaycastHit();

            if (collidedWith == null) return;

            localHolder =
                    collidedWith.gameObject.GetComponent<IHoldable>();

            ForceValidityCheck();
        }

        private void OnClickerValueUpdatedHandler(IteratorClicker _iterator,bool _result)
        {
            Debug.Log($"Iterator clicker value updated:",gameObject);
            ForceValidityCheck();
        }

        private void ForceValidityCheck()
        {
            //Check if iterators are correct
            iteratorsSolved = HasIteratorsBeenSolved();

            if(collidedWith != null)
            {
                var holderRef =
                    collidedWith.gameObject.GetComponent<IHoldable>();

                holderRef.PiecePlaced(this);
            }
        }

        public bool HasIteratorsBeenSolved()
        {
            var foundFalse = iterators.Any(it => !it.HasCorrectResponse);

            return !foundFalse;
        }

       
    }
}
