using DevStory.Gameplay.AudioPuzzle;
using UnityEngine;

namespace DevStory.Gameplay.Puzzles
{
    [System.Serializable]
    public struct RangeLimits
    {
       public float min;
       public float max;
    }

    public class AudioPuzzle : Puzzle
    {
        [Header("Audio Slider Components")]
        [SerializeField]
        private GameWave puzzleWave;


        [Space(10)]
        [Header("Puzzle Solving Ranges")]
        [SerializeField]
        private RangeLimits amplitudeLimits;

        [SerializeField]
        private RangeLimits frequencyLimits;


        protected override void Start()
        {
            puzzleWave = transform.GetChild(0).GetComponent<GameWave>();

            if(puzzleWave == null)
            {
                Debug.Log("Sin wave for audio puzzle not found",gameObject);
            }
        }

        public bool IsValueInRange(float x, float min, float max)
        {
            return x >= min && x <= max;
        }

        public override bool ValidityCheck()
        {
            //Check if frequency lies in the range
            bool isFrequencyValid = IsValueInRange(puzzleWave.Frequency, frequencyLimits.min, frequencyLimits.max);

            //Check if amplitude lies in the range
            bool isAmplitudeValid = IsValueInRange(puzzleWave.Amplitude, amplitudeLimits.min, amplitudeLimits.max);

            //Save value based on true or false
            if (isFrequencyValid && isAmplitudeValid)
            {
                return true;
            }

            return false;
        }
    }
}
