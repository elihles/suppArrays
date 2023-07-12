using System;

namespace suppArrays
{
    internal class Program
    {
        const int size = 10;

        static void Main(string[] args)
        {
            string[] bucketList = new string[size];
            int nrEl = 0;
            int choice;
            bool quit = false;

            do
            {
                choice = DisplayOptions();

                switch (choice)
                {
                    case 1:
                        AddItem(bucketList, ref nrEl);
                        break;
                    case 2:
                        DisplayItems(bucketList, nrEl);
                        break;
                    case 3:
                        RemoveItem(bucketList, ref nrEl);
                        break;
                    case 4:
                        Console.WriteLine("Goodbye");
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please select a suitable option (1-4).");
                        break;
                }

                Console.WriteLine();
                Console.ReadLine();
            } while (!quit);
        }

        static int DisplayOptions()
        {
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Display items");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");

            return int.Parse(Console.ReadLine());
        }

        static void AddItem(string[] bucketList, ref int nrEl)
        {
            if (nrEl < size)
            {
                Console.Write("Enter the item to add: ");
                string newItem = Console.ReadLine();

                bucketList[nrEl] = newItem;
                nrEl++;
                Console.WriteLine("Item was added to the list.");
            }
            else
            {
                Console.WriteLine("Bucket list is full. Cannot add more items.");
            }
        }

        static void DisplayItems(string[] bucketList, int nrEl)
        {
            if (nrEl == 0)
            {
                Console.WriteLine("Bucket list is empty.");
            }
            else
            {
                Console.WriteLine("Current Items in the Bucket List:");
                for (int i = 0; i < nrEl; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, bucketList[i]);
                }
            }
        }

        static void RemoveItem(string[] bucketList, ref int nrEl)
        {
            if (nrEl == 0)
            {
                Console.WriteLine("Bucket list is empty.");
            }
            else
            {
                Console.Write("Enter the item to remove: ");
                string itemToRemove = Console.ReadLine();

                int index = FindItem(bucketList, nrEl, itemToRemove);
                if (index != -1)
                {
                    for (int i = index; i < nrEl - 1; i++)
                    {
                        bucketList[i] = bucketList[i + 1];
                    }

                    nrEl--;
                    Console.WriteLine("Item removed from the list.");
                }
                else
                {
                    Console.WriteLine("Item not found in the list.");
                }
            }
        }

        static int FindItem(string[] bucketList, int nrEl, string item)
        {
            for (int i = 0; i < nrEl; i++)
            {
                if (bucketList[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
