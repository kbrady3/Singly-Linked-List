using System;
using System.Collections.Generic;
using System.Text;

namespace SinglyLinkedList
{
    class CanBrady
    {
        public string Company { get; set; }
        public string Content { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }

        public CanBrady() { }

        public CanBrady(string company, string content, double size, double price)
        {
            Company = company;
            Content = content;
            Size = size;
            Price = price;
        }

        public void DisplayCan()
        {
            string canDetails = "Company: " + Company + ", Content: " + Content + ", Size: " + Size + " ounces, Price: $" + Price;
            Console.WriteLine(canDetails);
        }
    }
}
