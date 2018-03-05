using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class InOrderTraversal
    {
        public void PrintBstInOrder(BinaryTreeNode root)
        {
            if (root == null) return;
            PrintBstInOrder(root.Left);
            Console.WriteLine(root.Value);
            PrintBstInOrder(root.Right);
        }

        public void ConnectRightOfLeafToOtherNearestRightLeaf(BinaryTreeNode root)
        {
            previousLeafNode = null;
            this.firstLeaf = null;
            var firstLeaf = FindFirstLeaf(root);
            ConnectRightOfLeafToOtherNearestRightLeafImpl(root);
            while (firstLeaf != null)
            {
                Console.WriteLine(firstLeaf.Value);
                firstLeaf = firstLeaf.Right;
            }
        }

        BinaryTreeNode previousLeafNode = null;
        private void ConnectRightOfLeafToOtherNearestRightLeafImpl(BinaryTreeNode root)
        {
            if (root == null) return;
            ConnectRightOfLeafToOtherNearestRightLeafImpl(root.Left);
            if(Utils.IsLeaf(root))
            {
                if (previousLeafNode != null)
                    previousLeafNode.Right = root;
                previousLeafNode = root;
           }
            ConnectRightOfLeafToOtherNearestRightLeafImpl(root.Right); 
        }

        public BinaryTreeNode ConvertSortedLinkedListToBst(LinkedList<int> list)
        {
            enumerator = list.GetEnumerator();
            var bt = ConvertSortedLinkedListToBstImpl(0, list.Count-1);
            enumerator.Dispose();
            return bt;
        }

        LinkedList<int>.Enumerator enumerator;
        private BinaryTreeNode ConvertSortedLinkedListToBstImpl(int low, int high)
        {
            if (low > high) return null;
            int mid = (low + high) / 2;

            var lc = ConvertSortedLinkedListToBstImpl(low, mid - 1);
            enumerator.MoveNext();
            var root = new BinaryTreeNode(enumerator.Current, lc);
            root.Right = ConvertSortedLinkedListToBstImpl(mid + 1, high);

            return root;
        }

        public BinaryTreeNode ConvertSortedArrayToBst(int[] arr, int low, int high)
        {
            if (low > high) return null;
            int mid = (low + high) / 2;

            var lc = ConvertSortedArrayToBst(arr, low, mid - 1);
            var root = new BinaryTreeNode(arr[mid], lc);
            root.Right = ConvertSortedArrayToBst(arr, mid + 1, high);

            return root;
        }

        public BinaryTreeNode ConvertBstToDoubleLinkedList(BinaryTreeNode root)
        {
            previous = null;
            head = null;
            ConvertBstToDoubleLinkedListImpl(root);
            return head;
        }
        BinaryTreeNode previous;
        BinaryTreeNode head;
        void ConvertBstToDoubleLinkedListImpl(BinaryTreeNode root)
        {
            if (root == null) return;
            ConvertBstToDoubleLinkedListImpl(root.Left);

            if (previous == null) head = root;
            root.Left = previous;
            if (previous != null) previous.Right = root;
            previous = root;

            ConvertBstToDoubleLinkedListImpl(root.Right);
        }

        /// <summary>
        /// GIVEN: Not a BST, The items need to be unique other wise there will be ambiquity.
        /// We start with a range [low, high]
        /// Now The first item will be the root in PreOrder. 
        /// Next we will find the index of that item in the inorder array
        /// The sizes of the left and right halves will be the sizes of the LST and RST 
        /// Then we map this sizes to the indexes of the pre order traversal
        /// 
        /// NOTE: For PostOrder+Inorder we know last element is the root
        /// </summary>
        public BinaryTreeNode RestoreTreeFromPreAndInOrderTraversals(int[] preOrder, int[] inOrder)
        {
            int idx = 0;
            IotIndexes = inOrder.ToDictionary(x => x, x => idx++);
            PreOrderTraversal = preOrder;
            return RestoreTreeFromPreAndInOrderTraversalsImpl(0, preOrder.Length - 1, 0, preOrder.Length - 1);
        }
        Dictionary<int, int> IotIndexes;
        int[] PreOrderTraversal;
        /// <summary>
        /// Need to maintain indexes for both the arrays
        /// </summary>
        private BinaryTreeNode RestoreTreeFromPreAndInOrderTraversalsImpl(int potlow, int pothigh
                                                                        , int iotlow, int iothigh)
        {
            if (potlow > pothigh) return null;
            var rootVal = PreOrderTraversal[potlow];
            var rootIdx = IotIndexes[rootVal];
            var ltsz = rootIdx - iotlow;
            
            var lc = RestoreTreeFromPreAndInOrderTraversalsImpl(potlow + 1, potlow+ltsz, iotlow, rootIdx-1);
            var root = new BinaryTreeNode(rootVal, lc);
            var rc = RestoreTreeFromPreAndInOrderTraversalsImpl(potlow+ltsz+1, pothigh, rootIdx+1, iothigh);
            root.Right = rc;
            return root;
        }

        BinaryTreeNode firstLeaf = null;
        private BinaryTreeNode FindFirstLeaf(BinaryTreeNode root)
        {
            if (firstLeaf != null) return firstLeaf;
            if (root == null) return root;
            FindFirstLeaf(root.Left);
            if(root.Left == null && root.Right == null)
            {
                firstLeaf = root;
                return firstLeaf;
            }
            FindFirstLeaf(root.Right);
            return firstLeaf;
        }
    }
}
