using article4;
using NUnit.Framework;
using System;

namespace NUnitTestArticle4
{
    public class Tests
    {
        graph g1;
        [SetUp]
        public void Setup()
        {
            g1 = new graph(6);
            g1.nodes[0].children = new node[3];
            g1.nodes[0].name = "0";
            g1.nodes[1].children = new node[2];
            g1.nodes[1].name = "1";
            g1.nodes[2].children = new node[1];
            g1.nodes[2].name = "2";
            g1.nodes[3].children = new node[2];
            g1.nodes[3].name = "3";
            g1.nodes[4].children = new node[0];
            g1.nodes[4].name = "4";
            g1.nodes[5].children = new node[0];
            g1.nodes[5].name = "5";

            g1.nodes[0].children[0] = g1.nodes[1];
            g1.nodes[0].children[1] = g1.nodes[4];
            g1.nodes[0].children[2] = g1.nodes[5];

            g1.nodes[1].children[0] = g1.nodes[3];
            g1.nodes[1].children[1] = g1.nodes[4];

            g1.nodes[2].children[0] = g1.nodes[1];

            g1.nodes[3].children[0] = g1.nodes[2];
            g1.nodes[3].children[1] = g1.nodes[4];

            g1.nodes[4].children = null;

            g1.nodes[5].children = null;
        }

        [Test]
        public void TestSearchDFSForGraph()
        {
            g1.searchDFS(g1.nodes[0]);
            for(int i=0;i<g1.nodes.Length;i++)
            {
                Assert.AreEqual(true, g1.nodes[i].visited);
            }
            g1.setVisitationFlagToFalse();
        }
        [Test]
        public void TestSearchBFSForGraph()
        {
            g1.searchBFS(g1.nodes[0]);
            for (int i = 0; i < g1.nodes.Length; i++)
            {
                Assert.AreEqual(true, g1.nodes[i].visited);
            }
            g1.setVisitationFlagToFalse();
        }
        [Test]
        public void TestisThereWayForGraph()
        {
            Assert.AreEqual(true, g1.isThereWay(g1.nodes[0], g1.nodes[3]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(true, g1.isThereWay(g1.nodes[0], g1.nodes[2]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(true, g1.isThereWay(g1.nodes[3], g1.nodes[1]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(true, g1.isThereWay(g1.nodes[1], g1.nodes[3]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(false, g1.isThereWay(g1.nodes[5], g1.nodes[0]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(false, g1.isThereWay(g1.nodes[3], g1.nodes[0]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(false, g1.isThereWay(g1.nodes[4], g1.nodes[0]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(false, g1.isThereWay(g1.nodes[4], g1.nodes[5]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(false, g1.isThereWay(g1.nodes[3], g1.nodes[0]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(false, g1.isThereWay(g1.nodes[4], g1.nodes[3]));
            g1.setVisitationFlagToFalse();
            Assert.AreEqual(false, g1.isThereWay(g1.nodes[4], g1.nodes[2]));
            g1.setVisitationFlagToFalse();
        }
        [Test]
        public void TestAddForBinaryTree()
        {
            int countOfEl = 100;
            Random rand = new Random(DateTime.Now.Millisecond);
            binaryTree<int> bt = new binaryTree<int>();
            for (int i = 0; i<countOfEl; i++)
            {

                bt.add(rand.Next());
            }
            Assert.AreEqual(countOfEl, bt.Count);
        }
    }
}