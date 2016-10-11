using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavannaGame_v10
{
    class Controller //Singleton
    {
        private static Controller instance = null;
        private Controller()
        {

        }

        internal Program Program
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public static Controller Get_Instance()
        {
            if (instance == null)
                instance = new Controller();
            return instance;
        }
        //Metode der samler metoderne til at tilføje tiles og runderne, så den kan kaldes fra main
        public void Start_Game()
        {
            Add_Tiles();
            Do_Turns();
        }
        //Metode der tilføjer brikker/tiles til spilpladen
        public void Add_Tiles()
        {
            for(int i = 0; i < 20; i++)//Add Rabbits
            {
                Board.Get_Instance().Add_Rabbit();
            }
            for (int i = 0; i < 15; i++)//Add Lions
            {
                Board.Get_Instance().Add_Lion();
            }
            for (int i = 0; i < 10; i++)//Add Grass
            {
                Board.Get_Instance().Add_Grass();
            }
            for (int i = 0; i < 10; i++)//Add Sand
            {
                Board.Get_Instance().Add_Sand();
            }
        }
        //Metode der starter turen, kører igennem de forskellige metoder der tilsammen udgør en runde
        public void Do_Turns()
        {
            while (true)
            {
                Board.Get_Instance().Move();//Animal Moves
                Board.Get_Instance().PrintBoard();
                Board.Get_Instance().Eat();//Animal Eat
                Board.Get_Instance().Mate();//Animal Mates
                Board.Get_Instance().Old_Age();//Animal Dies of Old Age
                Board.Get_Instance().PrintBoard();
            }
        }
    }
}
