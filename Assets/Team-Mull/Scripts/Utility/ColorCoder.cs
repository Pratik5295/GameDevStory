
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

                case PuzzlePaint.PURPLE:
                    return GetColorFromHex("#800080");
                    
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
                    return GetColorFromHex("#25e450");

                case TaskPriority.MEDIUM:
                    return GetColorFromHex("#ff531f");

                case TaskPriority.HIGH:
                    return GetColorFromHex("#b10600");

                default:
                    return Color.white;
            }
        }

        #endregion
    }
}
