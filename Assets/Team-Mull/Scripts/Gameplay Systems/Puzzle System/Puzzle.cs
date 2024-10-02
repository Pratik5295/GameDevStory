using UnityEngine;
using System.Collections.Generic;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.Puzzles
{
    public class Puzzle : MonoBehaviour
    {
        [SerializeField] private List<Holder> puzzleHolders = new List<Holder>();

        [SerializeField] private PuzzleStatus currentPuzzleStatus;
    }
}
