using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaGame_v10
{
    static class Rnd
    {
        /* Statisk klasse der genere et random tal,
         * den er venligst lånt af Jakup.
         * da den bruges mange gange, er dette den lettere løsning 
         * end at oprette og erklære den hver gang. */
        private static Random rnd = new Random();
        public static int Get_Random(int start, int slut)
        {
            return rnd.Next(start, slut);
        }
    }
}
