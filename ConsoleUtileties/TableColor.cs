using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtilities
{
    public struct TableColor
    {
        /// <summary>
        /// The foreground color of the lines seperating the table collumns
        /// Default: <see cref="Color.LightGray"/>
        /// </summary>
        public Color BorderForegroundColor
        {
            get;
            set;
        } = Color.LightGray;

        /// <summary>
        /// The background color of the lines seperating the table collumns
        /// Default: <see cref="ConsoleUtilities.consoleBlack"/>
        /// </summary>
        public Color BorderBackgroundColor
        {
            get;
            set;
        } = ConsoleUtilities.consoleBlack;

        /// <summary>
        /// Array of foreground colours for each header, color[0] = color of the 1. column header
        /// Default: All <see cref="Color.LightGray"/>
        /// </summary>
        public Color[] headerForegroundColors = Array.Empty<Color>();

        /// <summary>
        /// Array of foreground colours for each row, color[0] = color of the 1. row element
        /// Default: All <see cref="Color.LightGray"/>
        /// </summary>
        public Color[] columnForegroundColors = Array.Empty<Color>();

        /// <summary>
        /// 
        /// Default: All <see cref="ConsoleUtilities.consoleBlack"/>
        /// </summary>
        public Color[] headerBackgroundColors = Array.Empty<Color>();

        /// <summary>
        /// Default: All <see cref="ConsoleUtilities.consoleBlack"/>
        /// </summary>
        public Color[] columnBackgroundColors = Array.Empty<Color>();

        /// <summary>
        /// Default constructer eveything will have the default color (<see cref="Color.LightGray"/>)
        /// </summary>
        public TableColor ()
        {
        }

        /// <summary>
        /// Constructor with every color specefid
        /// </summary>
        /// <param name="borderForegroundColor">The foreground color of the lines seperating the table collumns</param>
        /// <param name="borderBackgroundColor">The background color of the lines seperating the table collumns</param>
        /// <param name="headerForegroundColors">Array of foreground colours for each header, color[0] = color of the 1. column header</param>
        /// <param name="columnForegroundColors">Array of foreground colours for each row, color[0] = color of the 1. row element</param>
        /// <param name="headerBackgroundColors">Array of background colours for each header, color[0] = color of the 1. column header</param>
        /// <param name="columnBackgroundColors">Array of background colours for each row, color[0] = color of the 1. row element</param>
        public TableColor (Color borderForegroundColor, Color borderBackgroundColor, Color[] headerForegroundColors, Color[] columnForegroundColors, Color[] headerBackgroundColors, Color[] columnBackgroundColors)
        {
            BorderForegroundColor = borderForegroundColor;
            BorderBackgroundColor = borderBackgroundColor;
            this.headerForegroundColors = headerForegroundColors;
            this.columnForegroundColors = columnForegroundColors;
            this.headerBackgroundColors = headerBackgroundColors;
            this.columnBackgroundColors = columnBackgroundColors;
        }
    }
}
