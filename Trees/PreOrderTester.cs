using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{

    [TestClass]
    public class PreOrderTester
    {
        PreOrderTraversal pot;

        [TestInitialize]
        public void SetUp()
        {
            pot = new PreOrderTraversal();
        }

        [TestMethod]
        public void TestIsBst()
        {
            var testBst = Utils.CreateTestBst();

            Assert.IsTrue(pot.IsBst(testBst));

            testBst.Left.Right.Value = 42;
            Assert.IsFalse(pot.IsBst(testBst));
        }

        [TestMethod]
        public void TestRestoreBstFromPreOrderedData()
        {
            int[] sarr = { 5, 3, 1, 4, 7 };
            var root = pot.RestoreBstFromPreOrderedData(sarr);

            Assert.AreEqual(root.Value, 5);
            Assert.AreEqual(root.Right.Value, 7);
            Assert.AreEqual(root.Left.Right.Value, 4);
            Assert.IsTrue(pot.IsBst(root));
        }
    }
}
