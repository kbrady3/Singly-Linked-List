using System;
using System.Collections.Generic;
using System.Text;

namespace SinglyLinkedList
{
    class LinkedList
    {
        private int First { get; set; }
        private int MaxSize { get; set; }
        private CanBrady[] ListItems { get; set; }

        public LinkedList()
        {
            First = -1;
            MaxSize = 10;
            ListItems = new CanBrady[MaxSize];
        }

        public void AddLast(CanBrady item)
        {
            if (ListItems[MaxSize - 1] == null)
            {
                ListItems[MaxSize - 1] = item;
            }
            else
            {
                throw new Exception("List is full");
            }
        }

        public void Add(int index, CanBrady item)
        {
            if (ListItems[index] == null)
            {
                ListItems[index] = item;
            }
            else
            {
                CanBrady[] tempArray = new CanBrady[100];
                CanBrady[] tempArray2 = new CanBrady[100];

                if (ListItems[MaxSize - 1] == null)
                {
                    try
                    {
                        //Array.Copy(originalArray, startIndex, newArray, startIndex, endIndex);

                        Array.Copy(ListItems, 0, tempArray, 0, index); //Copies the first part of the array (up to, but not including index)
                        Array.Copy(ListItems, index, tempArray2, index + 1, MaxSize - 1); //Copies the second part of the array (index inclusive to the end)

                        ListItems[index] = item; //Now that we have a backup of ListItems, we can overwrite the current value in index with the new value

                        Array.Copy(tempArray2, index + 1, tempArray, index + 1, MaxSize - 1); //Now we combine our temp arrays, so now everything is in tempArray, except there's a blank spot at index
                        tempArray[index] = item; //Copy the item to the blank spot

                        ListItems = tempArray; //Assign tempArray to ListItems
                    }
                    catch
                    {
                        throw new Exception("List is full");
                    }
                }
                else
                {
                    throw new Exception("List is full.");
                }
            }
        }

        public string PeekFirst()
        {
            //Looks at the first item in the array
            if (ListItems[0] != null)
            {
                return ListItems[0].Content + ", " + ListItems[0].Company + ", " + ListItems[0].Size + " ounces, $" + ListItems[0].Price + "\n"; 
            }
            else
            {
                throw new Exception("No element at index 0");
            }
        }

        public CanBrady RemoveFirst()
        {
            if (ListItems[0] != null)
            {
                CanBrady temp = ListItems[0];
                ListItems[0] = null;

                CanBrady[] tempArray = new CanBrady[MaxSize + 1];
                Array.Copy(ListItems, 1, tempArray, 0, MaxSize); //Moves items back one index by copying to tempArray

                ListItems = tempArray;

                return temp;
            }
            else
            {
                throw new Exception("No need to remove first element - no element present");
            }
        }

        public CanBrady Remove(int index)
        {
            CanBrady removed = ListItems[index];

            if (ListItems[index] == null)
            {
                throw new Exception("Nothing to remove - no element present at specified index");
            }
            else
            {
                for (int i = index; i < MaxSize; i++)
                {
                    if(i != MaxSize - 1)
                    {
                        ListItems[i] = ListItems[i + 1]; //Copies items back one index starting at index
                    }
                }
            }

            return removed;
        }

        public int Size()
        {
            int counter = 0;

            if (ListItems[0] != null)
            {
                for (int i = 0; i < MaxSize; i++)
                {
                    if (ListItems[i] != null)
                    {
                        counter++; //Counts each nonzero item in array
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                throw new Exception("List is empty");
            }

            return counter;
        }

        public string Print()
        {
            string concat = "";

            int size = Size();
            CanBrady[] temp = new CanBrady[size];

            Array.Copy(ListItems, 0, temp, 0, size);

            ListItems = temp; //Resizes the array to eliminate null values so that Array.Sort will work

            Array.Sort(ListItems, (x, y) => String.Compare(x.Content, y.Content)); //Sorts in alphabetical order

            foreach (CanBrady item in ListItems)
            {
                if(item != null)
                {
                    concat += item.Content + ", " + item.Company + ", " + item.Size + " ounces, $" + item.Price + "\n";
                }
            }

            return concat;
        }
    }
}