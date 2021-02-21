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
        public binaryTree()
        {
            root = null;
            count = 0;
        }
        public void add(T element)
        {
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
                treeNode<T> current = root;
                while(current != null)
                {
                    if(element.CompareTo(current.value) >= 0)
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
    
    }

}
