using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class PostOrderTraversal
    {
        public int GetTreeHeight(BinaryTreeNode root)
        {
            if (root == null) return 0;
            int leftHeight = GetTreeHeight(root.Left);
            int rightHeight = GetTreeHeight(root.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public BinaryTreeNode FindTheLowestCommonAnscestor(BinaryTreeNode root, BinaryTreeNode a, BinaryTreeNode b)
        {
            if (root == a || root == b) return root;
            if (root == null) return null;

            BinaryTreeNode left = FindTheLowestCommonAnscestor(root.Left, a, b);
            BinaryTreeNode right = FindTheLowestCommonAnscestor(root.Right, a, b);

            if (left != null && right != null) return root;

            return left == null ? right : left;
        }

        /* Uses Bottom up/Post OT approach to Find the subtreee which forms the 
         * Largest BST
         * O(n2) approach is to call BST at each node and keep the number of nodes
         * This approach makes it O(n)
         * Each subtree returns the range of values it has
         * Finally root compares itself to the ranges and passes on the info back
         */
        public BinaryTreeNode FindLargestSubBst(BinaryTreeNode root)
        {
            largestBst = null;
            maxNumberOfNodes = 0;
            FindLargestSubBstImpl(root);
            return largestBst;
        }

        //Small DS to encapsulate Return Values 
        private class LargestBst
        {
            public int MinValue = int.MaxValue; //Special vals are needed for handling leaf case
            public int MaxValue = int.MinValue; //Special
            public bool IsBst = false;
            public int NodeCount; 
        }
        BinaryTreeNode largestBst;
        int maxNumberOfNodes;

        private LargestBst FindLargestSubBstImpl(BinaryTreeNode root)
        {
            if (root == null) return new LargestBst { IsBst = true };
            var ldata = FindLargestSubBstImpl(root.Left);
            var rdata = FindLargestSubBstImpl(root.Right);

            if((ldata.IsBst && rdata.IsBst)
                && (root.Value > ldata.MaxValue && root.Value < rdata.MinValue))
            {
                var nodeCount = 1 + ldata.NodeCount + rdata.NodeCount;
                if(nodeCount > maxNumberOfNodes)
                {
                    maxNumberOfNodes = nodeCount;
                    largestBst = root;
                }

                // If no child is found the node itself gives the min/max value
                int minValue = ldata.NodeCount > 0 ? ldata.MinValue : root.Value;
                int maxValue = rdata.NodeCount > 0 ? rdata.MaxValue : root.Value;

                return new LargestBst { NodeCount = nodeCount, IsBst = true, MinValue = minValue
                                      , MaxValue = maxValue };
            }

            return new LargestBst();
        }
    }
}
