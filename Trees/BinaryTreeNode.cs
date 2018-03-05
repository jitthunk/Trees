using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BinaryTreeNode
    {
        public int Value;
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;

        public BinaryTreeNode NextRight; //Used in some of the problems

        public BinaryTreeNode(int val, BinaryTreeNode left = null, BinaryTreeNode right = null)
        {
            Value = val;
            Left = left;
            Right = right;
        }
    }
}
