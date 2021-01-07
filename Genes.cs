using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z0mziMath;

namespace Evolution
{
    public class Genes
    {
        public int lifeSpan;//in rounds

        public int height;//min: 1
        public int root;//min: 1
        public double dilemma;//0-1 > if closer to 0, higher chance to choose root growth if closer to 1 higher chance to choose height growth

        public int numOfSeeds;
        public int resourcesTransferred;

        public Dictionary<string, double> dominanceChance = new Dictionary<string, double>();

        public Genes(int lifeSpan, int height, int root, double dilemma, int numOfSeeds, int resourcesTransferred, Dictionary<string, double> dominanceChance)
        {
            this.lifeSpan = lifeSpan;
            this.height = height;
            this.root = root;
            this.dilemma = dilemma;
            this.numOfSeeds = numOfSeeds;
            this.resourcesTransferred = resourcesTransferred;
            this.dominanceChance = dominanceChance;
        }

        public static Genes generateRandom()
        {
            Random rnd = new Random();

            int lifeSpan = rnd.Next(25, 50);
            int height = rnd.Next(1, 10);
            int root = rnd.Next(1, 4);
            double dilemma = rnd.NextDouble();
            int numOfSeeds = rnd.Next(1, 4);
            int resourcesTransferred = rnd.Next(50, 100);

            Dictionary<string, double> dominanceChance = new Dictionary<string, double>();

            dominanceChance.Add("lif", rnd.NextDouble());
            dominanceChance.Add("hei", rnd.NextDouble());
            dominanceChance.Add("roo", rnd.NextDouble());
            dominanceChance.Add("dil", rnd.NextDouble());
            dominanceChance.Add("num", rnd.NextDouble());
            dominanceChance.Add("res", rnd.NextDouble());
            dominanceChance.Add("dom", rnd.NextDouble());

            return new Genes(lifeSpan, height, root, dilemma, numOfSeeds, resourcesTransferred, dominanceChance);
        }

        public void Modify(double strength)//my opinion: this should be around 0 >> new gene = gene * random(1 - strength, 1 + strength)
        {
            Random rnd = new Random();

            lifeSpan = Math.Max(10, (int)((double)lifeSpan * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength)));
            height *= Math.Max(1, (int)((double)lifeSpan * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength)));
            root *= Math.Max(1, (int)((double)lifeSpan * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength)));
            dilemma *= Mathf.Clamp((double)lifeSpan * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
            numOfSeeds *= Math.Max(1, (int)((double)lifeSpan * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength)));
            resourcesTransferred *= Math.Max(0, (int)((double)lifeSpan * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength)));

            dominanceChance["lif"] = Mathf.Clamp(dominanceChance["lif"] * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
            dominanceChance["hei"] = Mathf.Clamp(dominanceChance["hei"] * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
            dominanceChance["roo"] = Mathf.Clamp(dominanceChance["roo"] * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
            dominanceChance["dil"] = Mathf.Clamp(dominanceChance["dil"] * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
            dominanceChance["num"] = Mathf.Clamp(dominanceChance["num"] * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
            dominanceChance["res"] = Mathf.Clamp(dominanceChance["res"] * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
            dominanceChance["dom"] = Mathf.Clamp(dominanceChance["dom"] * Mathf.Map(rnd.NextDouble(), 0d, 1d, 1d - strength, 1d + strength), 0d, 1d);
        }
    }
}