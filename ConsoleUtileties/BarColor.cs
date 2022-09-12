using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtilitiesLibary
{
    /// <summary>
    /// Color config for all bar styles
    /// </summary>
    public struct BarColor
    {
        /// <summary>
        /// Color of Bar Title
        /// Default: <see cref="Color.LightGray"/>
        /// </summary>
        public Color TitleForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        /// <summary>
        /// Color of the Percentage Number
        /// Default: <see cref="Color.LightGray"/>
        /// </summary>
        public Color PercentageForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        /// <summary>
        /// Color of the Prentecies encasing the Bar
        /// Default: <see cref="Color.LightGray"/>
        /// </summary>
        public Color BarCasingForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        /// <summary>
        /// Color of the lines marking the progress
        /// Default: <see cref="Color.LightGray"/>
        /// </summary>
        public Color BarProgressForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        /// <summary>
        /// Background color of the title
        /// Default: <see cref="ConsoleUtilities.consoleBlack"/>
        /// </summary>
        public Color TitleBackgroundColor
        {
            get;
            set;
        } = ConsoleUtilities.consoleBlack;

        /// <summary>
        /// Background color of the percentage
        /// Default: <see cref="ConsoleUtilities.consoleBlack"/>
        /// </summary>
        public Color PercentageBackgroundColor
        {
            get;
            set;
        } = ConsoleUtilities.consoleBlack;

        /// <summary>
        /// Background color of the brackets encasing the ProgressBar
        /// Default: <see cref="ConsoleUtilities.consoleBlack"/>
        /// </summary>
        public Color BarCasingBackgroundColor
        {
            get;
            set;
        } = ConsoleUtilities.consoleBlack;

        /// <summary>
        /// Background color of the lines indicating the progress
        /// Default: <see cref="ConsoleUtilities.consoleBlack"/>
        /// </summary>
        public Color BarProgressBackgroundColor
        {
            get;
            set;
        } = ConsoleUtilities.consoleBlack;

        /// <summary>
        /// Default Construktor by default all colors will be <see cref="Color.LightGray"/>
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
