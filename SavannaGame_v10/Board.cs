using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

using System.Windows;

namespace SavannaGame_v10
{
    class Board //Singleton
    {
        private static Board instance = null;
        public Point[,] GameBoard = new Point[20, 20];
        private int turn;
        private string tile = "[      ]";
        public List<Animal> aL = new List<Animal>(); //Liste til dyre tiles
        public List<Ground> gL = new List<Ground>(); //Liste til grund tiles
        public Board()
        {

        }

        internal Controller Controller
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public static Board Get_Instance()
        {
            if (instance == null)
                instance = new Board();
            return instance;
        }
        //Metode der tilføjer løver til spillet
        public void Add_Lion()
        {
            Lion l = new Lion();
            int x = l.Get_Point().X;
            int y = l.Get_Point().Y;
            aL.Add(l);
        }
        //Metode der tilføje kaniner til spillet
        public void Add_Rabbit()
        {
            Rabbit r = new Rabbit();
            int x = r.Get_Point().X;
            int y = r.Get_Point().Y;
            aL.Add(r);
        }
        //Metode der tilføjer gras til spillet
        public void Add_Grass()
        {
            Grass g = new Grass();
            int x = g.Get_Point().X;
            int y = g.Get_Point().Y;
            gL.Add(g);
        }
        //Metode der tilføjer sand til spillet
        public void Add_Sand()
        {
            Sand s = new Sand();
            int x = s.Get_Point().X;
            int y = s.Get_Point().Y;
            gL.Add(s);
        }
        //Metode der printer spilpladen så den kan ses visuelt i consollen
        public void PrintBoard()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                                                                     [ The Savanna Game ]");
            Console.WriteLine();
            turn++;
            int rabbits = 0, r = 0;
            int lions = 0, l = 0;
            int sand = 0;
            int grass = 0;
            int col = GameBoard.GetLength(0);
            int row = GameBoard.GetLength(1);
            foreach (Animal a in aL)
            {
                if (a != null)
                {
                    if (a.Get_Type() == "[Rabbit]")
                        r++;
                    if (a.Get_Type() == "[ Lion ]")
                        l++;

                    if (aL != null)
                        if (a.p.X > -1 && a.p.X < 20)
                        {
                            if (a.p.Y > -1 && a.p.Y < 20)
                            {
                                GameBoard[a.p.X, a.p.Y] = a.p; //out of bound null ref?
                            }
                        }
                }
            }
            foreach (Ground g in gL)
            {
                if (aL != null)
                    if (g.p.X > -1 && g.p.X < 20)
                    {
                        if (g.p.Y > -1 && g.p.Y < 20)
                        {
                            GameBoard[g.p.X, g.p.Y] = g.p;
                        }
                    }
            }
            for(int x = 0; x < col; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    if (GameBoard != null)
                    {


                        foreach (Ground g in gL)
                        {
                            if (gL != null && g != null)
                            {
                                if (g.p == GameBoard[x, y])
                                    tile = g.Get_Type();
                            }

                        }
                        foreach (Animal a in aL)
                        {
                            if (aL != null && a != null)
                            {
                                if (a.p == GameBoard[x, y])
                                    tile = a.Get_Type();
                            }
                        }
                    }
                    if (tile == "[ //// ]")
                        grass++;
                    if (tile == "[ ¤¤¤¤ ]")
                        sand++;
                    if (tile == "[Rabbit]")
                        rabbits++;
                    if (tile == "[ Lion ]")
                        lions++;
                    Console.Write(tile);
                    Console.ResetColor();
                    tile = "[      ]";
                }
                Console.WriteLine();
            } 
            Console.WriteLine("Turn: "+turn);
            Console.WriteLine("amount of Lion's on the savanna: "+lions + ", Lion's listed: "+l);
            Console.WriteLine("amount of Rabbit's on the savanna: " + rabbits + ", Rabbit's listed: "+r);

            //Console.Read();
            Thread.Sleep(200);
        }
        //Metode der tilfældigt vælger en retning for dyr der skal flyttes
        public void Move()
        {
            int move = 0; 
            foreach (Animal a in aL)
            {
                if (aL != null)
                {
                    if (a != null)
                    {
                        move = Rnd.Get_Random(0, 5);
                        if (move == 0)
                            a.Move_Right();
                        if (move == 1)
                            a.Move_Left();
                        if (move == 2)
                            a.Move_Up();
                        if (move == 4)
                            a.Move_Down();
                    }
                }
            }
        }
        //Metode der tilføjer dyr til dyrelisten hvis der "fødes" dyr i en given runde
        public void Mate()
        {
            int rbabies = 0;
            int lbabies = 0;
            foreach (Animal a in aL)
            {
                if (a != null)
                {
                    if (a.Get_Type() == "[Rabbit]")
                        rbabies = a.Get_Layed(aL);
                    if (a.Get_Type() == "[ Lion ]")
                        lbabies = a.Get_Layed(aL);
                }

            }
            if(rbabies > 0)
            {
                Add_Rabbit();
                Add_Rabbit();
                Add_Rabbit();
                Add_Rabbit();
            }
            if(lbabies > 0)
            {
                Add_Lion();
                Add_Lion();
            }
        }
        //Metode der fjerner tiles fra listerne hvis der spises i en given runde
        public void Eat()
        {
            for(int i = 0; i < aL.Count; i++)
            {
                if(aL[i] != null)
                aL[i].Get_Eaten(aL,gL);
            }            
        }
        //Metode der fjerner dyr hvis de opnår en alder på 20 runder
        public void Old_Age()
        {
            for (int i = 0; i < aL.Count; i++)
            {
                if(aL[i] != null)
                if (aL[i].age >= 20)
                    aL[i] = null;
            }
        }
    }
}


