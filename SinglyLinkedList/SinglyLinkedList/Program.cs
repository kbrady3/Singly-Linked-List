using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CanBrady c1 = new CanBrady("Campbell's", "Tomato soup", 16.00, 3.50);
            CanBrady c2 = new CanBrady("Lipton", "Cream of chicken", 8.00, 2.75);
            CanBrady c3 = new CanBrady("Amy's", "Organic chicken broth", 16.00, 5.50);
            CanBrady c4 = new CanBrady("Healthy Choice", "Baked beans", 20.00, 3.75);
            CanBrady c5 = new CanBrady("Campbell's", "Corn", 20.00, 3.25);
            LinkedList l = new LinkedList();
            l.Add(0, c1);
            l.Add(1, c2);
            l.Add(2, c3);
            l.Add(3, c4);
            l.Add(4, c5);
            l.Remove(4);
            l.AddLast(c5);
            Console.WriteLine("Peek first: " + l.PeekFirst());
            Console.WriteLine(l.Print());
        }
    }
}
