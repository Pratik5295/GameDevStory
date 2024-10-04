
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Utility
{
    public static class ColorCoder
    {

        public static Color GetColor(PuzzlePaint _paint)
        {
            switch (_paint)
            {
                case PuzzlePaint.WHITE:
                    return  Color.white;

                case PuzzlePaint.RED:
                    return Color.red;

                case PuzzlePaint.GREEN:
                    return Color.green;

                case PuzzlePaint.BLUE:
                    return Color.blue;

                case PuzzlePaint.YELLOW:
                    return Color.yellow;

                case PuzzlePaint.ORANGE:
                    return new Color(37,33,35);


                    
                default:
                    return Color.black;


            }

        }
    }
}
