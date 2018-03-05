using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Mixed
    {
        public void PrintOuterNodes(BinaryTreeNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.Value);
            PrintLeftOuterNodes(root.Left, true);
            PrintRightOuterNodes(root.Right, true);
        }

        private void PrintLeftOuterNodes(BinaryTreeNode root, bool printOverride)
        {
            if (root == null) return;
            if (printOverride || Utils.IsLeaf(root))
                Console.WriteLine(root.Value);
            PrintLeftOuterNodes(root.Left, printOverride);
            PrintLeftOuterNodes(root.Right, false); // print only leaves of rt st
        }

        private void PrintRightOuterNodes(BinaryTreeNode root, bool printOverride)
        {
            if (root == null) return;
            PrintRightOuterNodes(root.Left, false);
            PrintRightOuterNodes(root.Right, printOverride);
            if (printOverride || Utils.IsLeaf(root))
                Console.WriteLine(root.Value); //rt st root is printed last
        }

    }
}
