using DevStory.Gameplay.DragDrop;
using System.Collections.Generic;
using UnityEngine;

namespace DevStory.Gameplay.Puzzles
{

    public class IteratorHolder : Holder
    {
        [SerializeField]
        private List<IteratorClicker> iterator = new List<IteratorClicker>();

    }
}
