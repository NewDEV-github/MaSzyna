using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;

namespace Assets.Scripts
{
    internal class Util
    {
        /// <summary>
        /// Method for converting MaSzyna's multivalued floats to C# bool
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Converted bool</returns>
        public static bool ParseBool(string value)
        {
            if (value == "1" || value == "yes" || value == "true" || value == "True")
                return true;
            else return false;
        }
        /// <summary>
        /// Method for converting non-float 0-255 values to float and get Color
        /// </summary>
        /// <param name="tokens">List of file tokens</param>
        /// <param name="iToken">Iteration of iToken</param>
        /// <returns>Converted Color</returns>
        public static Color ParseColor(ref List<string> tokens, ref int iToken)
        {
            float r, g, b;
            r = float.Parse(tokens[iToken + 1]);
            iToken++;
            g = float.Parse(tokens[iToken + 2]);
            iToken++;
            b = float.Parse(tokens[iToken + 3]);
            iToken++;

            Color color = new Color();
            if (r % 1 == 0)
                color.r = r / 255;
            else
                color.r = r;
            if (g % 1 == 0)
                color.g = g / 255;
            else
                color.g = g;
            if (b % 1 == 0)
                color.b = b / 255;
            else
                color.b = b;

            return color;
        }
    }
}
