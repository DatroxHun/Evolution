using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z0mziMath;

namespace Evolution
{
    class Evolution
    {

        public void Run(int rounds)
        {
            runOneRound();
        }


        public List<Plant> Plants = new List<Plant>();
        public List<List<string>> map = new List<List<string>>();

        private void runOneRound()
        {
            foreach (var item in Plants.OrderBy(x => new Random().NextDouble()).ToList())
            {
                item.calcOneRound();
            }
        }

        protected bool inMap(Vector2 pos)
        {
            //check if it is in the pos is in the map on the x coordinates
            if (pos.x > map.Count && pos.x <= 0)
            {
                //check if it is in the pos is in the map on the y coordinates
                if (pos.y > map[0].Count && pos.y <= 0)
                {
                    return true;
                }
            }

            return false;
        }
        protected Plant findPlantByCoord(Vector2 Coordinate)
        {
            foreach (var item in Plants)
            {
                if (item.Pos == Coordinate)
                {
                    return item;
                }
            }
            return null;
        }
        protected Vector2 normalizeCoordinate(Vector2 coord)
        {
            return new Vector2((coord.x+map.Count-1)% (map.Count - 1), (coord.y + map.Count - 1) % (map.Count - 1));
        }

    }
}
