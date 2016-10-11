using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaGame_v10
{
    public class Point
    {
        /* klasse til at tildele X og y værdi til dyr og grund, 
         * den er lavet for at slipe for at bruge den indbygget 
         * klasse i WindowsBase.dll, da den benytter en double og 
         * jeg skal kun bruge en int værdi */
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
