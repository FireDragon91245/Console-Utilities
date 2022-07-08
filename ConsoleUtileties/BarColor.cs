using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtilities
{
    public struct BarColor
    {
        public Color TitleForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        public Color PercentageForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        public Color BarCasingForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        public Color BarProgressForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        public Color TitleBackgroundColor
        {
            get;
            set;
        } = Color.FromArgb(13, 13, 13);

        public Color PercentageBackgroundColor
        {
            get;
            set;
        } = Color.FromArgb(13, 13, 13);

        public Color BarCasingBackgroundColor
        {
            get;
            set;
        } = Color.FromArgb(13, 13, 13);

        public Color BarProgressBackgroundColor
        {
            get;
            set;
        } = Color.FromArgb(13, 13, 13);

        /// <summary>
        /// Default Construktor by default all colors will be gray
        /// </summary>
        public BarColor ()
        {
        }

        /// <summary>
        /// Construktor with every color specefied
        /// </summary>
        /// <param name="titleForegroundColor">Color of Bar Title</param>
        /// <param name="percentageForegroundColor">Color of the Percentage Number</param>
        /// <param name="barCasingForegroundColor">Color of the Prentecies encasing the Bar</param>
        /// <param name="barProgressForegroundColor">Color of the lines marking the progress</param>
        /// <param name="barCasingBackgroundColor">Background color of the brackets encasing the ProgressBar</param>
        /// <param name="titleBackgroundColor">Background color of the title</param>
        /// <param name="barProgressBackgroundColor">Background color of the lines indicating the progress</param>
        /// <param name="percentageBackgroundColor">Background color of the percentage</param>
        public BarColor (Color titleForegroundColor, Color percentageForegroundColor, Color barCasingForegroundColor, Color barProgressForegroundColor, Color titleBackgroundColor, Color percentageBackgroundColor, Color barCasingBackgroundColor, Color barProgressBackgroundColor)
        {
            TitleForegroundColor = titleForegroundColor;
            PercentageForegroundColor = percentageForegroundColor;
            BarCasingForegroundColor = barCasingForegroundColor;
            BarProgressForegroundColor = barProgressForegroundColor;
            TitleBackgroundColor = titleBackgroundColor;
            PercentageBackgroundColor = percentageBackgroundColor;
            BarCasingBackgroundColor = barCasingBackgroundColor;
            BarProgressBackgroundColor = barProgressBackgroundColor;
        }
    }
}
