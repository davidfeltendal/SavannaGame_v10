using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaGame_v10
{ 
    class Ground
    {
        //Super klasse til tiles som sand og gras
        private int Id;
        private string type;
        public Point p;
        public Ground()
        {
            Set_Id(Board.Get_Instance().gL);
            Set_Point(Board.Get_Instance().GameBoard);
        }

        /// <value></value>
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
        //Metode der tildeler Id til Grund tiles
        private int Set_Id(List<Ground> gl)
        {
            if (gl.Count == 0)
            {
                Id = 0;
            }
            if (gl.Count != 0)
            {
                Id = gl.Count;
            }
            Id++;
            return Id;
        }
        //Metode der retunere Id for Grund "Tiles"
        public int Get_Id()
        {
            return Id;
        }
        //Metode der overskrives af Sand og Grass klassen
        public virtual string Get_Type()
        {
            type = "[   ?  ]";
            return type;
        }
        //Metode der sætter piont(x/y) til dyr så de kan placeres på spilpladen
        private Point Set_Point(Point[,] ar)
        {
            p = new Point(Rnd.Get_Random(0, 20), Rnd.Get_Random(0, 20));
            int X = p.X;
            int Y = p.Y;
            if (ar[X, Y] != null)
            {
                Set_Point(ar);
            }

            return p;
        }
        //Metode der retunere point(x/y) 
        public Point Get_Point()
        {
            return p;
        }
    }
}
