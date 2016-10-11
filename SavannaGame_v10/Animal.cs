using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SavannaGame_v10
{
    class Animal
    {
        //Super klasse til kaniner og løver
        private int Id;
        private string type;
        public Point p;
        public int Sex;//0 = Female, 1 = Male
        public int age;
        //Constructor til at oprette nye dyr
        public Animal()
        {
            age = 0;
            Set_Id(Board.Get_Instance().aL);
            Set_Point(Board.Get_Instance().GameBoard);
            Sex = Rnd.Get_Random(0, 2);
        }

        internal Board Board
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        //Metode der tildeler Id til dyr
        private int Set_Id(List<Animal> al)
        {
            if (al.Count == 0)
            {
                Id = 0;
            }
            if (al.Count != 0)
            {
                Id = al.Count;
            }
            Id++;
            return Id;
        }
        //Metode der retunere Id for dyr
        public int Get_Id()
        {
            return Id;
        }
        //Metode der overskrives af Rabbit og Lion klassen
        public virtual string Get_Type()
        {
            type = "[  ??  ]";
            return type;
        }
        //Metode der sætter piont(x/y) til dyr så de kan placeres på spilpladen
        private Point Set_Point(Point[,] ar)
        {
            p = new Point(Rnd.Get_Random(0,20),Rnd.Get_Random(0,20));
                    int X = p.X;
                    int Y = p.Y;
                    if (ar[X, Y] != null)
                    {
                        Set_Point(ar);
                    }
            return p;
        }
        //Metode der retunere point(x/y) så det kan bruges til eks. move
        public Point Get_Point()
        {
            if (p.X < -1 && p.X > 20)
            {
                Get_Point();
            }
            else if(p.Y < -1 && p.Y > 20)
            {
                Get_Point();
            }
            return p;
        }
        //Metode der flytter dyr
        public virtual Point Move_Right()
        {
            int nX = 0;
            int nY = 0;
            for (int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    if(Board.Get_Instance().GameBoard[i,j] == p)
                    {
                        nX = i;
                        nY = j;
                        Board.Get_Instance().GameBoard[i, j] = null;
                    }
                }
            }
            if (nX < 19)
                nX++;

            p.X = nX; // mangler equal tjek i aL og gL
            age++;
            return p;
        }
        //Metode der flytter dyr
        public virtual Point Move_Left()
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
                nX--;

            p.X = nX;
            age++;
            return p;
        }
        //Metode der flytter dyr
        public virtual Point Move_Up()
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
                nY++;

            p.Y = nY;
            age++;
            return p;
        }
        //Metode der flytter dyr
        public virtual Point Move_Down()
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
                nY--;

            p.Y = nY;
            age++;
            return p;
        }
        //Metode overskrives i subklasserne
        public virtual int Get_Layed(List<Animal> al)
        {
            return 0;
        }
        //Metode overskrives i subklasserne
        public virtual void Get_Eaten(List<Animal> al, List<Ground> gl)
        {
            
        }        
    }
}
