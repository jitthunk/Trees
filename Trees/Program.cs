using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var pot = new PreOrderTraversal();
            pot.IterativePreOrder(Utils.CreateTestBst());

        }
    }
}
