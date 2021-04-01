using System;
using System.Collections;
using System.Collections.Generic;

namespace article4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class node
    {
        public string name;
        public node[] children;
        public bool visited;
        public node()
        {
            name = "";
            visited = false;
        }
    }
    public class graph
    {
        public node[] nodes;
        public graph(uint countOfNodes)
        {
            nodes = new node[countOfNodes];
            for (int i = 0; i < countOfNodes; i++)
            {
                nodes[i] = new node();
            }
        }
        public void searchDFS(node n)
        {
            if (n == null)
                return;
            n.visited = true;
            if (n.children != null)
            {
                foreach (node item in n.children)
                {
                    if (item.visited != true)
                        searchDFS(item);
                }
            }
        }
        public void searchBFS(node n)
        {
            if (n != null)
            {
                Queue q = new Queue();
                n.visited = true;
                q.Enqueue(n);
                while (q.Count != 0)
                {
                    node tmp = q.Dequeue() as node;
                    if (tmp.children != null)
                    {
                        foreach (node item in tmp.children)
                        {
                            if (item.visited != true)
                            {
                                item.visited = true;
                                q.Enqueue(item);
                            }
                        }
                    }
                }
            }
        }
        public void setVisitationFlagToFalse()
        {
            if (this.nodes != null)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i].visited = false;
                }
            }
        }
        public bool isThereWay(node a, node b)
        {
            bool res = false;
            if (a != null && b != null)
            {
                Queue q = new Queue();
                a.visited = true;
                q.Enqueue(a);
                while (q.Count > 0)
                {
                    node n = q.Dequeue() as node;
                    if (n == b)
                    {
                        res = true;
                        break;
                    }
                    if (n.children != null)
                    {
                        for (int i = 0; i < n.children.Length; i++)
                        {
                            if (n.children[i].visited != true)
                            {
                                n.children[i].visited = true;
                                q.Enqueue(n.children[i]);
                            }
                        }
                    }
                }
            }
            return res;
        }
        public Queue<node> orderProjects()
        {
            Queue<node> res = new Queue<node>();
            for(int i=0;i<nodes.Length;i++)
            {
                if (nodes[i].visited != true)
                    buildOrder(res, nodes[i]);
            }
            return res;
        }
        private void buildOrder(Queue<node> q, node n)
        {
            if (n==null)
            {
                return;
            }
            n.visited = true;
            if(n.children != null)
            {
                for (int i = 0; i < n.children.Length; i++)
                {
                    if (n.children[i].visited != true)
                        buildOrder(q, n.children[i]);
                }
            }
            q.Enqueue(n);
        }
    }
    public class treeNode<T> where T : IComparable<T>
    {
        public T value;
        public treeNode<T> left;
        public treeNode<T> right;
        public treeNode<T> parent;
        public treeNode() : this(Comparer<T>.Default)
        {
            value = default(T);
            left = null;
            right = null;
            parent = null;
        }
        private IComparer<T> comparer;
        public treeNode(IComparer<T> defaultComparer)
        {
            if (defaultComparer == null) throw new ArgumentNullException();
            comparer = defaultComparer;
        }
    }
    public class binaryTree<T> where T : IComparable<T>
    {
        public treeNode<T> root;
        private uint count;
        public uint Count
        {
            get { return count; }
        }
        private uint maxLvl;
        public uint MaxLvl
        {
            get { return maxLvl; }
        }
        public binaryTree()
        {
            root = null;
            count = 0;
        }
        public void add(T element)
        {
            uint lvl = 0;
            if (root == null)
            {
                root = new treeNode<T>();
                root.value = element;
                root.parent = null;
                root.left = null;
                root.right = null;
                count++;
            }
            else
            {
                lvl = addTo(root, element);
                if (lvl > maxLvl)
                    maxLvl = lvl;
                count++;
            }
        }
        public void getAll(Queue q, treeNode<T> node)
        {
            if (node == null)
                return;
            getAll(q, node.left);
            q.Enqueue(node);
            getAll(q, node.right);
        }
        public void buildMinTreeFromMas(T[] mas, int start, int end)
        {
            //if (start == end)
            //{
            //    add(mas[start]);
            //    return;
            //}
            if (start > end)
                return;
            int mid = (end + start) / 2;
            add(mas[mid]);
            buildMinTreeFromMas(mas, start, mid - 1);

            buildMinTreeFromMas(mas, mid + 1, end);
        }
        private uint addTo(treeNode<T> node, T element, uint startLvl = 0)
        {
            uint lvl = startLvl;
            if (node != null)
            {
                treeNode<T> current = root;
                while (current != null)
                {
                    lvl++;
                    if (element.CompareTo(current.value) >= 0)
                    {
                        if (current.right == null)
                        {
                            current.right = new treeNode<T>();
                            current.right.value = element;
                            current.right.parent = current;
                            break;
                        }
                        current = current.right;
                    }
                    else
                    {
                        if (current.left == null)
                        {
                            current.left = new treeNode<T>();
                            current.left.value = element;
                            current.left.parent = current;
                            break;
                        }
                        current = current.left;
                    }
                }
            }
            return lvl;
        }
        private treeNode<T> buildMinTree(T[] mas, int start, int end, treeNode<T> parent)
        {
            if (start > end)
                return null;
            treeNode<T> n = new treeNode<T>();
            int mid = (start + end) / 2;
            n.value = mas[mid];
            n.parent = parent;
            n.left = buildMinTree(mas, start, mid - 1, n);
            n.right = buildMinTree(mas, mid + 1, end, n);
            return n;
        }
        public void buildMinTreeFromMas(T[] mas)
        {
            if (mas.Length > 0 && root == null)
            {
                root = new treeNode<T>();
                root.parent = null;
                int mid = (mas.Length - 1) / 2;
                root.value = mas[mid];
                root.left = buildMinTree(mas, 0, mid - 1, root);
                root.right = buildMinTree(mas, mid + 1, mas.Length - 1, root);
                count = (uint)mas.Length;
                maxLvl = (uint)Math.Log2(count);
            }
        }
        public LinkedList<treeNode<T>>[] createList()
        {
            LinkedList<treeNode<T>>[] mas = new LinkedList<treeNode<T>>[maxLvl];
            LinkedList<treeNode<T>> list = new LinkedList<treeNode<T>>();
            list.AddFirst(root);
            mas[0] = list;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                LinkedList<treeNode<T>> newList = new LinkedList<treeNode<T>>();
                foreach (treeNode<T> item in mas[i])
                {
                    if (item != null)
                    {
                        if (item.left != null)
                            newList.AddFirst(item.left);
                        if (item.right != null)
                            newList.AddFirst(item.right);
                    }
                }
                mas[i + 1] = newList;
            }
            return mas;
        }
        public bool checkIsBalanced()
        {
            bool res = false;
            int min = (int)count;
            int max = 0;
            findMaxAndMinDepth(root, ref max, ref min, -1);
            if (max - min == 1 || max - min == 0)
                res = true;
            return res;
        }
        private void findMaxAndMinDepth(treeNode<T> n, ref int max, ref int min, int lvl)
        {
            if (n == null)
            {
                if (lvl > max)
                    max = lvl;
                else if (lvl < min)
                    min = lvl;
                return;
            }
            lvl++;
            findMaxAndMinDepth(n.left, ref max, ref min, lvl);
            findMaxAndMinDepth(n.right, ref max, ref min, lvl);
        }
        public bool isSeachTree(treeNode<T> n)
        {
            bool res = true;
            if (n != null)
            {
                res = checkIsBTS(n, default(T), default(T));
            }
            return res;
        }
        private bool checkIsBTS(treeNode<T> n, T min, T max)
        {
            if (n == null)
                return true;
            if ((min.CompareTo(default(T)) != 0 && n.value.CompareTo(min) < 0) || (max.CompareTo(default(T)) != 0 && n.value.CompareTo(max) >= 0))
                return false;
            if (checkIsBTS(n.left, min, n.value) && checkIsBTS(n.right, n.value, max))
                return true;
            return false;
        }
        public treeNode<T> findNext(treeNode<T> n)
        {
            if (n == null)
                return null;
            if (n.right != null)
            {
                return findTheMostLeft(n.right);
            }
            else
            {
                treeNode<T> p = n.parent;
                while (n != null && n != p.left)
                {
                    p = p.parent;
                    n = p;
                }
                return p;
            }
        }
        private treeNode<T> findTheMostLeft(treeNode<T> n)
        {
            while (n.left != null)
            {
                n = n.left;
            }
            return n;
        }
        private struct resultNodes
        {
            public treeNode<T> a;
            public treeNode<T> b;
            public treeNode<T> commonParent;
        }
        public treeNode<T> findFirtCommonParent(treeNode<T> a, treeNode<T> b)
        {
            if (a == b)
                return a.parent;
            if (a == null || b == null)
                return null;
            resultNodes comParent = new resultNodes();
            comParent = findFirtParent(a, b, root);
            return comParent.commonParent;
        }
        private resultNodes findFirtParent(treeNode<T> a, treeNode<T> b, treeNode<T> next)
        {
            resultNodes res = new resultNodes();
            if (next == null)
                return res;
            if (a == next)
                res.a = next;
            if (b == next)
                res.b = next;
            resultNodes resLeft = findFirtParent(a, b, next.left);
            if (resLeft.commonParent == null)
            {
                resultNodes resRight = findFirtParent(a, b, next.right);
                if (resRight.a != null)
                    res.a = resRight.a;
                if (resRight.b != null)
                    res.b = resRight.b;
                if (resRight.commonParent != null)
                    res.commonParent = resRight.commonParent;
            }
            if (resLeft.a != null)
                res.a = resLeft.a;
            if (resLeft.b != null)
                res.b = resLeft.b;
            if (resLeft.commonParent != null)
                res.commonParent = resLeft.commonParent;
            if (res.a != null && res.b != null && res.commonParent == null)
            {
                res.commonParent = next;
            }
            return res;
        }

        public treeNode<T> findFistCommonParentWithoutParent(treeNode<T> a, treeNode<T> b)
        {
            int depthA = depth(a);
            int depthB = depth(b);
            treeNode<T> first = depthA < depthB ? a : b;
            treeNode<T> second = depthA < depthB ? b : a;
            second = goUP(second, Math.Abs(depthA - depthB));
            while (first != null && second != null && first != second)
            {
                first = first.parent;
                second = second.parent;
            }
            return first == null || second == null ? null : first;
        }
        private int depth(treeNode<T> a)
        {
            int depth = 0;
            treeNode<T> current = a;
            while (current != null)
            {
                current = current.parent;
                depth++;
            }
            return depth;
        }
        private treeNode<T> goUP(treeNode<T> a, int lvl)
        {
            treeNode<T> current = a;
            while (lvl != 0)
            {
                current = current.parent;
                lvl--;
            }
            return current;
        }
        public List<List<T>> getAllVariatOfTree(treeNode<T> node)
        {
            List<List<T>> res = new List<List<T>>();
            if(node == null)
            {
                res.Add( new List<T>());
                return res;
            }
            List<T> prefix = new List<T>();
            prefix.Add(node.value);
            List<List<T>> lSeq = getAllVariatOfTree(node.left);
            List<List<T>> rSeq = getAllVariatOfTree(node.right);
            foreach(List<T> left in lSeq)
            {
                foreach (List<T> right in rSeq)
                {
                    weaved(left, right, res, prefix);
                }
            }
            return res;
        }
        private void weaved(List<T> left, List<T> right, List<List<T>> results, List<T> prefix)
        {
            if(left.Count < 1 || right.Count < 1)
            {
                List<T> result = new List<T>();
                copyToList(prefix, result);
                result.AddRange(left);
                result.AddRange(right);
                results.Add(result);
                return;
            }
            T el = left[0];
            left.RemoveAt(0);
            prefix.Add(el);
            weaved(left, right, results, prefix);
            left.Insert(0, el);
            prefix.RemoveAt(prefix.Count - 1);

            el = right[0];
            right.RemoveAt(0);
            prefix.Add(el);
            weaved(left, right, results, prefix);
            right.Insert(0, el);
            prefix.RemoveAt(prefix.Count - 1);
        }
        private void copyToList(List<T> source, List<T> desination)
        {
            foreach(T item in source)
            {
                T el = item;
                desination.Add(el);
            }
        }
        public int[][] generateTransposition(int[] elements)
        {
            if (elements == null || elements.Length < 1)
                return null;
            int countOfTrans = factorial(elements.Length);
            int lenghtOfElements = elements.Length;
            int[][] res = new int[countOfTrans][];
            Stack<int> clearPlaces = new Stack<int>();
            //int clearPlace = -1;
            int nextFreeMas = elements.Length;
            int countOfMas = elements.Length;
            for (int i = 0; i < elements.Length; i++)
            {
                res[i]= new int[lenghtOfElements];
                res[i][0] = elements[i];
            }
            for (int i=0;i<elements.Length;i++)
            {
                int countOfAddedEl = 0;
                for(int k=0;k<countOfMas && k < res.Length && countOfMas <= countOfTrans; k++)
                {
                    int[] tmpMas = res[k];
                    if(tmpMas != null && countNotNullElementsInMas(tmpMas) < elements.Length)
                    {
                        if (!contains(tmpMas, elements[i]))
                        {
                            res[k] = insertIntoMas(tmpMas, elements[i], 0);
                            int masLenght = countNotNullElementsInMas(tmpMas);
                            for (int j = 1; j <= masLenght; j++)
                            {
                                if (clearPlaces.Count > 0)
                                {
                                    res[clearPlaces.Pop()] = insertIntoMas(tmpMas, elements[i], j);
                                }
                                else
                                {
                                    res[nextFreeMas] = insertIntoMas(tmpMas, elements[i], j);
                                    nextFreeMas++;
                                    countOfAddedEl++;
                                }
                            }
                        }
                        else
                        {
                            res[k] = null;
                            clearPlaces.Push(k);
                        }
                    }
                }
                countOfMas += countOfAddedEl;
            }
            return res;
        }
        public int factorial(int n)
        {
            int res = 1;
            for(int i=2;i<=n;i++)
            {
                res = res * i;
            }
            return res;
        }
        private int [] insertIntoMas(int [] mas, int el, int pos)
        {
            if (mas == null || mas.Length < 1 || pos > mas.Length || pos < 0)
                return null;
            int[] res = new int[mas.Length];
            mas.CopyTo(res, 0);
            if (mas.Length-1 == pos)
            {
                res[mas.Length - 1] = el;
                return res;
            }
            for (int i=mas.Length-2;i>=0;i--)
            {
                if(i == pos)
                {
                    res[i + 1] = res[i];
                    res[i] = el;
                    break;
                }
                res[i + 1] = res[i];
            }
            return res;
        }
        private bool contains(int[] mas,int el)
        {
            bool res = false;
            for(int i=0;i<mas.Length;i++)
            {
                if(mas[i] == el)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
        private int countNotNullElementsInMas(int[] mas)
        {
            int res = 0;
            for(int i=0;i<mas.Length;i++)
            {
                if (mas[i] != 0)
                    res++;
            }
            return res;
        }
    }
}
