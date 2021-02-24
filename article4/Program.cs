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
    public class binaryTree <T> where T : IComparable<T>
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
            if(root == null)
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
            int mid = (end + start)/2;
            add(mas[mid]);
            buildMinTreeFromMas(mas, start, mid - 1);
            
            buildMinTreeFromMas(mas, mid+1, end);
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
            if(mas.Length > 0 && root == null)
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
    }

}
