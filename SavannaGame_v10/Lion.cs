using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaGame_v10
{
    class Lion :Animal
    {
        //Løve klasse der aver fra "Animal"
        public Lion() :base()
        {

        }
        //Metode der retunere en string til at printe
        public override string Get_Type()
        {
            string type = "[ Lion ]";
            Console.BackgroundColor = ConsoleColor.Yellow;
            return type;
        }
        //Metoder der ser om der er mulighed for at parre sig, hvis det er muligt tilføjes der nye dyr
        public override int Get_Layed(List<Animal> al)
        {
            int lBabies = 0;
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
                                    if (a is Lion)
                                    {
                                        if (a.Sex != b.Sex)
                                            lBabies++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return lBabies;
        }
        //Metode der ser om der er "mad" omkring deres felt, og spiser hvis det er
        public override void Get_Eaten(List<Animal> al, List<Ground> gl)
        {
            List<Animal> EatList = new List<Animal>();
            foreach(Animal a in al)
            {
                if(a is Lion)
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
                    foreach (Animal b in al)
                    {
                        if (b != null)
                        {
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (b.p == arr[i])
                                {
                                    if (b is Rabbit)
                                    {
                                        EatList.Add(b);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (Animal A in EatList)
                al.Remove(A);
        }
    }
}
