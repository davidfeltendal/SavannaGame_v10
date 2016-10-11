using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaGame_v10
{
    class Rabbit :Animal
    {
        //Kanin klasse der aver fra "Animal"
        public Rabbit() :base()
        {

        }
        //Metode der retunere en string til at printe
        public override string Get_Type()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            string type = "[Rabbit]";
            return type;
        }
        //Metode der flytter dyr, overskriver metoden fra superklassen
        public override Point Move_Right()
        {
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (Board.Get_Instance().GameBoard[i, j] == p)
                    {
                        nX = i;
                        nY = j;
                        Board.Get_Instance().GameBoard[i, j] = null;
                    }
                }
            }
            if (nX < 19)
                nX = nX + 2;

            p.X = nX; // mangler equal tjek i aL og gL
            age++;
            return p;
        }
        //Metode der flytter dyr, overskriver metoden fra superklassen
        public override Point Move_Left()
        {
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (Board.Get_Instance().GameBoard[i, j] == p)
                    {
                        nX = i;
                        nY = j;
                        Board.Get_Instance().GameBoard[i, j] = null;
                    }
                }
            }
            if (nX < 19)
                nX = nX - 2;

            p.X = nX;
            age++;
            return p;
        }
        //Metode der flytter dyr, overskriver metoden fra superklassen
        public override Point Move_Up()
        {
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (Board.Get_Instance().GameBoard[i, j] == p)
                    {
                        nX = i;
                        nY = j;
                        Board.Get_Instance().GameBoard[i, j] = null;
                    }
                }
            }
            if (nY < 19)
                nY = nY + 2;

            p.Y = nY;
            age++;
            return p;
        }
        //Metode der flytter dyr, overskriver metoden fra superklassen
        public override Point Move_Down()
        {
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (Board.Get_Instance().GameBoard[i, j] == p)
                    {
                        nX = i;
                        nY = j;
                        Board.Get_Instance().GameBoard[i, j] = null;
                    }
                }
            }
            if (nY < 19)
                nY = nY - 2;

            p.Y = nY;
            age++;
            return p;
        }
        //Metoder der ser om der er mulighed for at parre sig, hvis det er muligt tilføjes der nye dyr
        public override int Get_Layed(List<Animal> al)
        {
            int rBabies = 0;
            foreach (Animal a in al)
            {
                Point[] arr = new Point[8];
                if (a != null)
                {
                    
                    if (a.p.X > 0 && a.p.Y > 0)
                    {
                        if (a.p.X < 19 && a.p.Y < 19)
                        {
                            arr[0] = Board.Get_Instance().GameBoard[a.p.X - 1, a.p.Y - 1];
                            arr[1] = Board.Get_Instance().GameBoard[a.p.X - 1, a.p.Y];
                            arr[2] = Board.Get_Instance().GameBoard[a.p.X - 1, a.p.Y + 1];

                            arr[3] = Board.Get_Instance().GameBoard[a.p.X, a.p.Y - 1];
                            arr[4] = Board.Get_Instance().GameBoard[a.p.X, a.p.Y + 1];

                            arr[5] = Board.Get_Instance().GameBoard[a.p.X + 1, a.p.Y - 1];
                            arr[6] = Board.Get_Instance().GameBoard[a.p.X + 1, a.p.Y];
                            arr[7] = Board.Get_Instance().GameBoard[a.p.X + 1, a.p.Y + 1];
                        }
                    }
                }
                foreach (Animal b in al)
                {
                    if (b != null)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (b.p == arr[i])
                            {
                                if (a.Get_Type() == b.Get_Type())
                                {
                                    if (a is Rabbit)
                                    {
                                        if (a.Sex != b.Sex)
                                            rBabies++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return rBabies;
        }
        //Metode der ser om der er "mad" omkring deres felt, og spiser hvis det er
        public override void Get_Eaten(List<Animal> al,List<Ground> gl)
        {
            List<Ground> EatList = new List<Ground>();
            foreach (Animal a in al)
            {
                if (a is Rabbit)
                {
                    Point[] arr = new Point[8];
                    if (a.p.X > 0 && a.p.Y > 0)
                    {
                        if (a.p.X < 19 && a.p.Y < 19)
                        {
                            arr[0] = Board.Get_Instance().GameBoard[a.p.X - 1, a.p.Y - 1];
                            arr[1] = Board.Get_Instance().GameBoard[a.p.X - 1, a.p.Y];
                            arr[2] = Board.Get_Instance().GameBoard[a.p.X - 1, a.p.Y + 1];

                            arr[3] = Board.Get_Instance().GameBoard[a.p.X, a.p.Y - 1];
                            arr[4] = Board.Get_Instance().GameBoard[a.p.X, a.p.Y + 1];

                            arr[5] = Board.Get_Instance().GameBoard[a.p.X + 1, a.p.Y - 1];
                            arr[6] = Board.Get_Instance().GameBoard[a.p.X + 1, a.p.Y];
                            arr[7] = Board.Get_Instance().GameBoard[a.p.X + 1, a.p.Y + 1];
                        }
                    }
                    foreach (Ground g in gl)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (g.p == arr[i])
                            {
                                if (g is Grass)
                                {
                                    EatList.Add(g);
                                }
                            }
                        }
                    }
                }
            }
            foreach (Ground g in EatList)
                gl.Remove(g);
        }
    }
}
