using UnityEngine;
using UnityEngine.Events;

namespace DevStory.Gameplay.Puzzles
{
    public class Puzzle : MonoBehaviour
    {
        public UnityEvent OnPuzzleSolvedEvent;

        protected virtual void Start()
        {

        }


        public virtual bool ValidityCheck()
        {
            return false;
        }
    }
}
