﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaGame_v10
{
    class Grass :Ground
    {
        //Gras klasse der aver fra "Ground"
        public Grass():base()
        {

        }
        //Metode der retunere en string til at printe
        public override string Get_Type()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            string type = "[ //// ]";
            return type;
        }
    }
}
