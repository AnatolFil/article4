using article4;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

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
            int countOfEl = 1000;
            Random rand = new Random(DateTime.Now.Millisecond);
            binaryTree<int> bt = new binaryTree<int>();
            for (int i = 0; i<countOfEl; i++)
            {

                bt.add(rand.Next());
            }
            Assert.AreEqual(countOfEl, bt.Count);
        }
        [Test]
        public void TestGetAllForBinaryTree()
        {
            int countOfEl = 1000;
            Random rand = new Random(DateTime.Now.Millisecond);
            binaryTree<int> bt = new binaryTree<int>();
            Queue q = new Queue();
            for (int i = 0; i < countOfEl; i++)
            {
                bt.add(rand.Next());
            }
            bt.getAll(q, bt.root);
            while(q.Count>1)
            {
                int first = (q.Dequeue() as treeNode<int>).value;
                int second = (q.Dequeue() as treeNode<int>).value;
                Assert.IsTrue(first <= second);
            }
            Assert.AreEqual(countOfEl, bt.Count);
        }
        [Test]
        public void TestBuildMinTreeFromMasForBinaryTree()
        {
            for(int j=0;j < 100; j++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int countOfEl = rand.Next(0,10000);
                binaryTree<int> bt = new binaryTree<int>();
                int[] mas = new int[countOfEl];
                for (int i = 0; i < countOfEl; i++)
                {
                    mas[i] = i;
                }
                bt.buildMinTreeFromMas(mas, 0, countOfEl - 1);
                double lvl = Math.Log2(countOfEl);
                uint natLvl = (uint)lvl;
                Assert.AreEqual(natLvl, bt.MaxLvl);
                Assert.AreEqual(countOfEl, bt.Count);
            }
        }
        [Test]
        public void TestBuildMinTreeFromMasFasterForBinaryTree()
        {
            for (int j = 0; j < 100; j++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int countOfEl = rand.Next(0, 10000);
                binaryTree<int> bt = new binaryTree<int>();
                int[] mas = new int[countOfEl];
                for (int i = 0; i < countOfEl; i++)
                {
                    mas[i] = i;
                }
                bt.buildMinTreeFromMas(mas);
                double lvl = Math.Log2(countOfEl);
                uint natLvl = (uint)lvl;
                Assert.AreEqual(natLvl, bt.MaxLvl);
                Assert.AreEqual(countOfEl, bt.Count);
            }
        }
        [Test]
        public void TestCreateListForBinaryTree()
        {
            for (int j = 0; j < 100; j++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int countOfEl = rand.Next(0, 10000);
                binaryTree<int> bt = new binaryTree<int>();
                for (int i = 0; i < countOfEl; i++)
                {
                    bt.add(rand.Next(0, 10));
                }
                LinkedList<treeNode<int>>[] mas = bt.createList();
            
                Assert.AreEqual(countOfEl, bt.Count);
                Assert.AreEqual(bt.MaxLvl, mas.Length);
            }
        }
        [Test]
        public void TestCheckIsBalancedForBinaryTree()
        {
            for (int j = 0; j < 100; j++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int countOfEl = rand.Next(0, 10000);
                binaryTree<int> bt = new binaryTree<int>();
                for (int i = 0; i < countOfEl; i++)
                {
                    bt.add(i);
                }
                Assert.AreEqual(false, bt.checkIsBalanced());
                int[] mas = new int[countOfEl];
                for (int i = 0; i < countOfEl; i++)
                {
                    mas[i] = rand.Next();
                }
                Array.Sort(mas);
                binaryTree<int> BalancedBt = new binaryTree<int>();
                BalancedBt.buildMinTreeFromMas(mas);
                Assert.AreEqual(true, BalancedBt.checkIsBalanced());
            }
        }
    }
}