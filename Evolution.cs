using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    class Evolution
    {

        public void Run(int rounds)
        {

        }

        List<Plant> Plants = new List<Plant>();
        private void runOneRound()
        {
            foreach (var item in Plants)
            {
                item.calcOneRound();
            }
        }
    }
}
