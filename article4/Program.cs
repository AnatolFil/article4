using System;

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
    }
    public class graph
    {
        public node[] nodes;
    }
}
