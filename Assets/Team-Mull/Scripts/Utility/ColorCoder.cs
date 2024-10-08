
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
                    return GetColorFromHex("#ffA500");


                    
                default:
                    return Color.black;


            }

        }

        private static Color GetColorFromHex(string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out Color newColor);

            return newColor;
        }


        #region UI Color Getter

        public static Color GetColorFromPriority(TaskPriority priority)
        {
            switch(priority)
            {
                case TaskPriority.DEFAULT:
                    return Color.white;

                case TaskPriority.LOW:
                    return Color.green;

                case TaskPriority.MEDIUM:
                    return Color.yellow;

                case TaskPriority.HIGH:
                    return Color.red;

                default:
                    return Color.white;
            }
        }

        #endregion
    }
}
