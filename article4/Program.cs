using System;
using System.Collections;

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
            for(int i=0;i<countOfNodes;i++)
            {
                nodes[i] = new node();
            }
        }
        public void searchDFS(node n)
        {
            if (n == null)
                return;
            n.visited = true;
            if(n.children != null)
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
            if(n!=null)
            {
                Queue q = new Queue();
                n.visited = true;
                q.Enqueue(n);
                while(q.Count != 0)
                {
                    node tmp = q.Dequeue() as node;
                    if(tmp.children != null)
                    {
                        foreach(node item in tmp.children)
                        {
                            if(item.visited != true)
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
            if(this.nodes != null)
            {
                for(int i=0;i<nodes.Length;i++)
                {
                    nodes[i].visited = false;
                }
            }
        }
        public bool isThereWay(node a, node b)
        {
            bool res = false;
            if(a != null && b != null)
            {
                Queue q = new Queue();
                a.visited = true;
                q.Enqueue(a);
                while(q.Count>0)
                {
                    node n = q.Dequeue() as node;
                    if(n==b)
                    {
                        res = true;
                        break;
                    }                    
                    if(n.children != null)
                    {
                        for(int i=0;i<n.children.Length;i++)
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
    
}
