using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Tacklebox
{
    internal class Chance
    {
        /// <summary> Returns true every "1 out of x times" (2 .. x .. maxInt)</summary>
        public static bool OneOut(int x)
        {
            return Main.rand.NextBool(Math.Max(1,x));
        }

        /// <summary> Returns true in x percent of cases (0 .. x .. 100) </summary>
        public static bool Perc(float x)
        {
            return (Main.rand.NextFloat() < ( Math.Clamp(x,0f,100f) / 100.0f) ); //TODO: test it
        }

        /// <summary> Returns true in x percent of cases (0 .. x .. 1)</summary>
        public static bool Perc2(float x)
        {
            return (Main.rand.NextFloat() < Math.Clamp(x, 0f, 1f)); //TODO: test it
        }
    }
}
