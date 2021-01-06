using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z0mziMath;

namespace Evolution
{
    class Plant
    {
        Plant(Vector2 _pos)
        {
            Pos = _pos;
            genes = Genes.generateRandom();
        }
        public Vector2 Pos { get; private set; }
        public Genes genes { get; private set;  }

        public void calcOneRound()
        {
            //here the "flowchart" should be implimented

        }
        private void getResources()
        {

        }


        private void reproduce()
        {

        }

        
    }
    class Genes
    {

        public static Genes generateRandom()
        {
            Random random = new Random();

            float height = random.Next(100)/100;
            float gy0kerek = random.Next(100) / 100;
            float reproduce = random.Next(300) / 100;

            return new Genes(height,gy0kerek,reproduce);
        }


        public float height;
        public float gy0kerek;
        public float reproduce;

        public Genes(float height, float gy0kerek, float reproduce)
        {
            this.height = height;
            this.gy0kerek = gy0kerek;
            this.reproduce = reproduce;
        }
    }
}
