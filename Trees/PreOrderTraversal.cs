using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class PreOrderTraversal
    {
        /*
        * Given a FULL Binary tree populate nextRight
        * pointers to point to the right most node
        * Idea: To do a PreOrdertraversal. we will set the NextRights for the 2 children
        * So the nextRightPointers of the root of each subtree is already set
         */
        public void ConnectRightMostPointers(BinaryTreeNode root)
        {
            if (root == null) return;
            if(root.Left != null)
                root.Left.NextRight = root.Right;

            if (root.Right != null)
                root.Right.NextRight = root.NextRight == null ? null : root.NextRight.Left;

            ConnectRightMostPointers(root.Left);
            ConnectRightMostPointers(root.Right);
        }

        public bool IsBst(BinaryTreeNode root, int minVal = int.MinValue, int maxVal = int.MaxValue)
        {
            if (root == null) return true;
            if(root.Value > minVal && root.Value < maxVal)
            {
                return IsBst(root.Left, minVal, root.Value) 
                    && IsBst(root.Right, root.Value, maxVal);
            }
            return false;
        }

        /*
         * One way would be to use the Insert procedure, that is O(nlogn)
         * This method takes O(n)
         * Sample Usage would be to deserialze BST from file
        */
        int[] arr;
        int aidx;
        public BinaryTreeNode RestoreBstFromPreOrderedData(int[] arr, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            this.arr = arr;
            aidx = 0;
            return RestoreBstFromPreOrderedDataImpl(minValue, maxValue);
        }
        private BinaryTreeNode RestoreBstFromPreOrderedDataImpl(int minValue, int maxValue)
        {
            if (aidx >= arr.Length) return null;
            int val = arr[aidx];
            if (val > minValue && val < maxValue)
            {
                var root = new BinaryTreeNode(val);
                aidx++;
                root.Left = RestoreBstFromPreOrderedDataImpl(minValue, val);
                root.Right = RestoreBstFromPreOrderedDataImpl(val, maxValue);
                return root;
            }

            return null;
        }

        /// <summary>
        /// Each stack represents the 2 states a node can be in
        /// s0: Printing itself and calling Print on Left ST
        /// s1: Calling Printing right ST
        /// This is a generic approach to be applied for IN and POST order as well
        /// </summary>
        /// <param name="root"></param>
        public void IterativePreOrder(BinaryTreeNode root)
        {
            //NOTE FOR PreOrder MAX(S0.Count) = 1
            // Can replace by a single variable printMe
            s0 = new Stack<BinaryTreeNode>();
            s0.Push(root);
            s1 = new Stack<BinaryTreeNode>();
            IterativePreOrderImpl();
        }
        Stack<BinaryTreeNode> s0;
        Stack<BinaryTreeNode> s1;
        private void IterativePreOrderImpl()
        {
            while(s0.Count > 0 || s1.Count > 0)
            {
                while(s0.Count > 0)
                {
                    var n0 = s0.Pop();
                    if (n0 == null) continue;
                    Console.WriteLine(n0.Value);
                    s0.Push(n0.Left);
                    s1.Push(n0);
                }

                if(s1.Count > 0)
                {
                    var n1 = s1.Pop();
                    s0.Push(n1.Right);
                }
            }
        }
    }
}
