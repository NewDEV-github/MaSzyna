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
        public static bool ParseBool(string str)
        {
            if (str == "1" || str == "yes" || str == "true" || str == "True")
                return true;
            else return false;
        }
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
