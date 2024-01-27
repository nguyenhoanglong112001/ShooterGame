using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame
{
    public class GameHelper
    {
        public static int GetRandomValue(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        public static double GetRandomvalue(double min, double max)
        {
            Random r = new Random();
            return Math.Round(r.NextDouble() *(max - min)  + min,2);

        }
    }
}
