using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    [TestClass]
    public class PostOrderTester
    {
        PostOrderTraversal pot = null;

        [TestInitialize]
        public void SetUp()
        {
            pot = new PostOrderTraversal();
        }

        [TestMethod]
        public void TestFindTheLowestCommonAnscestor()
        {
            var root = Utils.CreateTestBst();

            var a = root.Left.Left;
            var b = root.Right.Right;
            Assert.AreEqual(root, pot.FindTheLowestCommonAnscestor(root, a, b));

            a = root.Left.Right;
            b = root.Left.Left;
            Assert.AreEqual(root.Left, pot.FindTheLowestCommonAnscestor(root, a, b));

            a = root.Left.Right;
            b = root.Left.Right;
            Assert.AreEqual(root.Left.Right, pot.FindTheLowestCommonAnscestor(root, a, b));
        }

        [TestMethod]
        public void TestFindLargestSubBst()
        {
            var root = Utils.CreateTestBst();
            var lroot = pot.FindLargestSubBst(root);

            Assert.AreEqual(root, lroot);

            root.Right.Value = 100;
            lroot = pot.FindLargestSubBst(root);
            Assert.AreEqual(root.Left, lroot);

            root.Left.Value = 100;
            lroot = pot.FindLargestSubBst(root);
            Assert.AreEqual(root.Left.Left, lroot);
        }
    }
}
