using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Bfs
    {
        public void PrintTreeInLevelOrder(BinaryTreeNode root)
        {
            var unmarked = new List<BinaryTreeNode>();
            unmarked.Add(root);
            while (unmarked.Count > 0)
            {
                var tmp = new List<BinaryTreeNode>();
                foreach (var bn in unmarked)
                {
                    Console.Write("{0} ", bn.Value);
                    if (bn.Left != null) tmp.Add(bn.Left);
                    if (bn.Right != null) tmp.Add(bn.Right);
                }
                Console.WriteLine();
                unmarked.Clear();
                unmarked.AddRange(tmp);
            }
        }

        public void PrintTreeInLevelOrderZigZag(BinaryTreeNode root)
        {
            var unmarked = new List<BinaryTreeNode>();
            unmarked.Add(root);

            var zag = false;
            while (unmarked.Count > 0)
            {
                var tmp = new List<BinaryTreeNode>();
                var printMe = new List<int>();
                foreach (var bn in unmarked)
                {
                    printMe.Add(bn.Value);
                    if (bn.Left != null) tmp.Add(bn.Left);
                    if (bn.Right != null) tmp.Add(bn.Right);
                }
                if (zag) printMe.Reverse();
                zag ^= true;
                printMe.ForEach(x => Console.Write("{0} ", x));

                Console.WriteLine();
                unmarked.Clear();
                unmarked.AddRange(tmp);
            }
        }
    }
}
