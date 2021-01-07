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
        Plant(Vector2 _pos, Genes genes, float energyGiven)
        {

            Pos = _pos;
            genes = Genes.generateRandom();
            enegry = energyGiven;
        }
        public static void Create(Vector2 _pos, Genes genes, float energyGiven)
        {
            //stuff to do when creating a new plant
            Evolution.Plants.Add(new Plant(_pos, genes, energyGiven));
        }
        public Vector2 Pos { get; private set; }
        public Genes genes { get; private set; }

        private float enegry;

        public void calcOneRound()
        {
            //here the "flowchart" should be implimented
            getResources();
            reproduce();
        }
        private void getResources()
        {

        }


        private void reproduce()
        {
            if (genes.reproduce.nOfChildren * 100 + genes.reproduce.extraEnegyBeforeChilren > enegry)
            {
                Random random = new Random();
                Plant.Create(Pos + new Vector2(random.NextDouble() < 0.5 ? -1 : 1, random.NextDouble() < 0.5 ? -1 : 1), genes, genes.reproduce.energyForChildren);
                //conditions met for children
            }
        }
    }

    class Reproduce
    {
        public static Reproduce generateRandom()
        {
            Random random = new Random();

            return new Reproduce(random.Next(4), random.Next(1000) / 100);
        }
        public int nOfChildren;
        public float extraEnegyBeforeChilren;
        /// <summary>
        /// not updated, needs to be properly implemented
        /// </summary>
        public float energyForChildren = 50;

        public Reproduce(int nOfChildren, float extraEnegyBeforeChilren)
        {
            this.nOfChildren = nOfChildren;
            this.extraEnegyBeforeChilren = extraEnegyBeforeChilren;
        }
    }
}
