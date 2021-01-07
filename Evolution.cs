using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    class Evolution
    {

        public static void Run(int rounds)
        {
            runOneRound();
        }

        public static List<Plant> Plants = new List<Plant>();
        private static void runOneRound()
        {
            foreach (var item in Plants)
            {
                item.calcOneRound();
            }
        }
    }
}
