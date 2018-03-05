using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Utils
    {
        /*                  8
         *            5          15
         *          2   6     10    20
         *        1       7   9
         */
        public static BinaryTreeNode CreateTestBst()
        {
            var lst = bt(5, bt(2, bt(1)), bt(6,  null, bt(7)));
            var rst = bt(15, bt(10, bt(9)), bt(20));
            var root = bt(8, lst, rst);
            return root;
        }

        static BinaryTreeNode bt(int value, BinaryTreeNode left = null, BinaryTreeNode right = null)
        {
            return new BinaryTreeNode(value, left, right);
        }

        internal static bool IsLeaf(BinaryTreeNode root)
        {
            return root.Left == null && root.Right == null;
        }
    }
}
