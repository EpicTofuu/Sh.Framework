using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sh.Framework.Maths
{
    public static class utils
    {
        /// <summary>
        /// Mathematically checks if number is within range
        /// </summary>
        /// <param name="n">number to compare</param>
        /// <param name="min">minimum end of range</param>
        /// <param name="max">maximum end of range</param>
        /// <returns></returns>
        public static bool inRange(int n, int min, int max)
        {
            if (n >= min && n <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
