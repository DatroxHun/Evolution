using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z0mziMath;

namespace Evolution
{
    class Plant : Evolution
    {
        Plant(Vector2 _pos, Genes genes, float energyGiven)
        {

            Pos = _pos;
            genes = Genes.generateRandom();
            enegry = energyGiven;
        }
        public void Create(Vector2 _pos, Genes genes, float energyGiven)
        {
            //stuff to do when creating a new plant
            Plants.Add(new Plant(_pos, genes, energyGiven));
        }
        public Vector2 Pos { get; private set; }
        public Genes Genes { get; private set; }
        public int Height { get; private set; }

        private float enegry;

        public void calcOneRound()
        {
            //here the "flowchart" should be implimented
            getResources();
            reproduce();
        }
        private void getResources()
        {
            List<float> energyOnTiles = new List<float>();
            //go through the nearby plants to get how many energy the tiles have.
            for (int x = -1; x <= 1; x++)
            {
                //Loop throught the 8 nearby cells to check how many energy they have.
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0)
                    {
                        //need to skip, to only check cells near it
                        continue;
                    }
                    Vector2 enrgyPos = new Vector2(Pos.x + x, Pos.y + y);
                    if (inMap(enrgyPos))
                    {
                        energyOnTiles.Add(enegryOnTile(enrgyPos,Height));
                    }
                }
            }
        }
        private float enegryOnTile(Vector2 Pos,int onHight)
        {
            //if the tile has a bigger plant then there is zero energy
            if (findPlantByCoord(Pos).Height > onHight)
            {
                return 0;
            }
            int nOfBigger = 0;
            //to determine how many enegrgy they have, loop through the cells near that and check how many objects are bigger than it.
            for (int Ex = -1; Ex <= 1; Ex++)
            {
                for (int Ey = -1; Ey <= 1; Ey++)
                {
                    //check if higher and if that exists.
                    if (findPlantByCoord(new Vector2(Ex,Ey)+Pos).Height>onHight && )
                    {
                        nOfBigger++;
                    }
                }
            }
            float eTemp = 100;//energy to divide
            for (int i = 0; i <= nOfBigger; i++)
            {
                eTemp = eTemp / 2;
            }
            return eTemp;
        }


        private void reproduce()
        {
            //check if enough energy to reproduce
            if (this.Genes.reproduce.nOfChildren * 100 + this.Genes.reproduce.extraEnegyBeforeChilren > enegry)
            {
                //if enough then calculate this
                Random random = new Random();
                Create(Pos + new Vector2(random.NextDouble() < 0.5 ? -1 : 1, random.NextDouble() < 0.5 ? -1 : 1), this.Genes, this.Genes.reproduce.energyForChildren);
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
