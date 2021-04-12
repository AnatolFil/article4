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
        [Test]
        public void TestIsSeachTreeForBinaryTree()
        {
            for (int j = 0; j < 1000; j++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int countOfEl = rand.Next(0, 10000);
                binaryTree<int> bt = new binaryTree<int>();
                for (int i = 0; i < countOfEl; i++)
                {
                    bt.add(rand.Next());
                }
                Assert.AreEqual(true, bt.isSeachTree(bt.root));
                LinkedList<treeNode<int>>[] mas = bt.createList();
                bool isFindedLvl = false;
                while(isFindedLvl != true)
                {
                    int randInd = rand.Next(1, mas.Length - 1);
                    if (mas[randInd].First != null && mas[randInd].First.Next != null && mas[randInd].First.Value.parent == mas[randInd].First.Next.Value.parent)
                    {
                        int tmp = mas[randInd].First.Value.value;
                        mas[randInd].First.Value.value = mas[randInd].First.Next.Value.value;
                        mas[randInd].First.Next.Value.value = tmp;
                        isFindedLvl = true;
                        Assert.AreEqual(false, bt.isSeachTree(bt.root));
                    }
                }
            }
        }
        [Test]
        public void TestFindNextForBinaryTree()
        {
            for (int j = 0; j < 100; j++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int countOfEl = rand.Next(0, 10000);
                int[] mas = new int[countOfEl];
                for (int i = 0; i < countOfEl; i++)
                {
                    mas[i] = rand.Next();
                }
                binaryTree<int> bt = new binaryTree<int>();
                for (int i = 0; i < countOfEl; i++)
                {
                    bt.add(mas[i]);
                }
                LinkedList<treeNode<int>>[] Lvlmas = bt.createList();
                Array.Sort(mas);
                int randInd = rand.Next(1, Lvlmas.Length - 1);
                treeNode<int> nextEl = bt.findNext(Lvlmas[randInd].First.Value);
                if(nextEl != null)
                {
                    for(int i=0;i<countOfEl;i++)
                    {
                        if(mas[i] == Lvlmas[randInd].First.Value.value  && i+1 < countOfEl)
                        {
                            Assert.AreEqual(mas[i+1], nextEl.value);
                        }
                    }
                }
            }
        }
        [Test]
        public void TestOrderProjectsorGraph()
        {
            Queue<node> q = null;
            q = g1.orderProjects();
            for (int i = 0; i < g1.nodes.Length; i++)
            {
                Assert.AreEqual(true, g1.nodes[i].visited);
            }
            Assert.AreEqual(q.Count, g1.nodes.Length);
            g1.setVisitationFlagToFalse();
        }
        [Test]
        public void TestFindFirtCommonParentForBinaryTree()
        {
            for (int j = 0; j < 100; j++)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int countOfEl = rand.Next(0, 10000);
                int[] mas = new int[countOfEl];
                for (int i = 0; i < countOfEl; i++)
                {
                    mas[i] = rand.Next();
                }
                binaryTree<int> bt = new binaryTree<int>();
                for (int i = 0; i < countOfEl; i++)
                {
                    bt.add(mas[i]);
                }
                LinkedList<treeNode<int>>[] Lvlmas = bt.createList();
                int randInd1 = rand.Next(1, Lvlmas.Length - 1);
                int randInd2 = rand.Next(1, Lvlmas.Length - 1);
                if (Lvlmas[randInd1].First.Value != null && Lvlmas[randInd2].First.Value != null)
                {
                    treeNode<int> comPar = bt.findFirtCommonParent(Lvlmas[randInd1].First.Value, Lvlmas[randInd2].First.Value);
                    Assert.AreEqual(true, comPar != null);    
                }
            }
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13, 17, 12 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length - 1; i++)
            {
                bt1.add(mas1[i]);
            }
            LinkedList<treeNode<int>>[] Lvlmas1 = bt1.createList();
            treeNode<int> comPar1 = bt1.findFirtCommonParent(bt1.root.left.right, bt1.root.left.left.left);
            Assert.AreEqual(10, comPar1.value);
            comPar1 = bt1.findFirtCommonParent(bt1.root.left.right.right, bt1.root.left.left.left);
            Assert.AreEqual(10, comPar1.value);
            comPar1 = bt1.findFirtCommonParent(bt1.root.left.left, bt1.root.left.left.left);
            Assert.AreEqual(5, comPar1.value);
            comPar1 = bt1.findFirtCommonParent(bt1.root.left.left, bt1.root.right.right.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFirtCommonParent(bt1.root.left.left, bt1.root.right.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFirtCommonParent(bt1.root.left, bt1.root.right.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFirtCommonParent(bt1.root.left, bt1.root.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFirtCommonParent(bt1.root.right.left.left, bt1.root.right.right.left);
            Assert.AreEqual(30, comPar1.value);
        }
        [Test]
        public void TestFindFistCommonParentWithoutParentForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13, 17, 12 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length - 1; i++)
            {
                bt1.add(mas1[i]);
            }
            treeNode<int> comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.left.right, bt1.root.left.left.left);
            Assert.AreEqual(10, comPar1.value);
            comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.left.right.right, bt1.root.left.left.left);
            Assert.AreEqual(10, comPar1.value);
            comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.left.left, bt1.root.left.left.left);
            Assert.AreEqual(5, comPar1.value);
            comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.left.left, bt1.root.right.right.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.left.left, bt1.root.right.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.left, bt1.root.right.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.left, bt1.root.right);
            Assert.AreEqual(20, comPar1.value);
            comPar1 = bt1.findFistCommonParentWithoutParent(bt1.root.right.left.left, bt1.root.right.right.left);
            Assert.AreEqual(30, comPar1.value);
        }
        [Test]
        public void TestGenerateTranspositionForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 7, 13 };
            binaryTree<int> bt1 = new binaryTree<int>();
            int[][] traspositions = bt1.generateTransposition(mas1);
            Assert.AreEqual(24, traspositions.Length);
        }
        [Test]
        public void TestGetAllVariatOfTreeForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length; i++)
            {
                bt1.add(mas1[i]);
            }
            List<List<int>> res = bt1.getAllVariatOfTree(bt1.root);
            //Assert.AreEqual(24, traspositions.Length);
        }
        [Test]
        public void TestTreeToMasForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length; i++)
            {
                bt1.add(mas1[i]);
            }
            int[] mas = new int[mas1.Length];
            int ind = -1;
            bt1.treeToMas(bt1.root, ref mas, ref ind);
            //Assert.AreEqual(24, traspositions.Length);
        }
        [Test]
        public void TestContainsForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13 };
            binaryTree<int> bt1 = new binaryTree<int>();
            binaryTree<int> bt2 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length; i++)
            {
                bt1.add(mas1[i]);
                if(i>mas1.Length/2)
                    bt2.add(mas1[i]);
            }
            bool res = bt1.Contains(bt1.root.right.left);
            Assert.AreEqual(true, res);
            res = bt1.Contains(bt2.root);
            Assert.AreEqual(false, res);
            res = bt1.Contains(bt1.root.right.right);
            Assert.AreEqual(true, res);
            res = bt1.Contains(bt1.root);
            Assert.AreEqual(true, res);
            res = bt1.Contains(bt1.root.left);
            Assert.AreEqual(true, res);
            res = bt1.Contains(bt1.root.left.left.left);
            Assert.AreEqual(true, res);
            res = bt1.Contains(bt1.root.left.right);
            Assert.AreEqual(true, res);
        }
        [Test]
        public void TestFindForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length; i++)
            {
                bt1.add(mas1[i]);
            }
            Assert.AreEqual(20, bt1.find(20).value);
            Assert.AreEqual(30, bt1.find(30).value);
            Assert.AreEqual(10, bt1.find(10).value);
            Assert.AreEqual(25, bt1.find(25).value);
            Assert.AreEqual(15, bt1.find(15).value);
            Assert.AreEqual(27, bt1.find(27).value);
            Assert.AreEqual(7, bt1.find(7).value);
            Assert.AreEqual(13, bt1.find(13).value);
        }
        [Test]
        public void TestDelForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length; i++)
            {
                bt1.add(mas1[i]);
            }
            bt1.del(30);
            Assert.AreEqual(bt1.root.right.value, bt1.find(40).value);
            Assert.AreEqual(25, bt1.find(40).left.left.value);
            Assert.AreEqual(24, bt1.find(40).left.left.left.value);
            Assert.AreEqual(27, bt1.find(40).left.left.right.value);
            Assert.AreEqual(39, bt1.find(40).left.value);
            Assert.AreEqual(45, bt1.find(40).right.value);
            bt1.del(15);
            Assert.AreEqual(13, bt1.find(10).right.value);
            Assert.AreEqual(null, bt1.find(10).right.left);
            Assert.AreEqual(null, bt1.find(10).right.right);
            bt1.del(10);
            Assert.AreEqual(bt1.root.left.value, bt1.find(13).value);
            Assert.AreEqual(5, bt1.find(13).left.value);
            Assert.AreEqual(3, bt1.find(5).left.value);
            Assert.AreEqual(7, bt1.find(5).right.value);
            bt1.del(27);
            Assert.AreEqual(null, bt1.find(25).right);
            Assert.AreEqual(24, bt1.find(25).left.value);
        }
        [Test]
        public void TestGetRandomForBinaryTree()
        {
            int[] mas1 = { 20, 30, 10, 40, 25, 5, 15, 45, 39, 24, 27, 3, 7, 13 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length; i++)
            {
                bt1.add(mas1[i]);
            }
            treeNode<int> node =  null;
            for(int i=0;i<100000; i++)
            {
                node = bt1.getRandom();
                Assert.AreNotEqual(null, node);
            }
        }
        [Test]
        public void TestGetAllSumForBinaryTree()
        {
            int[] mas1 = { 4, 20, -1,16, -7, -10, 9, 14, 11, -3, 0, 17, 1, 22 };
            binaryTree<int> bt1 = new binaryTree<int>();
            for (int i = 0; i < mas1.Length; i++)
            {
                bt1.add(mas1[i]);
            }
            int res = bt1.getAllSum(-4, bt1.root);
            Assert.AreEqual(1, res);
            res = bt1.getAllSum(63, bt1.root);
            Assert.AreEqual(1, res);
            res = bt1.getAllSum(0, bt1.root);
            Assert.AreEqual(0, res);
        }
    }
}