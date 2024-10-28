using UnityEngine;
using System.Collections.Generic;
using static MetaConstants.EnumManager.EnumManager;
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
