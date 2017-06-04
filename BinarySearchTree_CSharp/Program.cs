using System;

namespace BinarySearchTree_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            Console.WriteLine("\nWelcome to BST Data strucutre\n");
            Console.WriteLine("\nPlease enter the elements in the space seperated format\n");
            int[] dataArr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            foreach (int item in dataArr)
            {
                tree.Insert(item);
            }

            int choice = -1;
            int data = 0;
            while(choice != 0)
            {
                Console.WriteLine("\n\n1.Insert\n2.Pre Order\n3.In Order\n4.Post Order\n5.Number of Nodes\n" +
                    "6.Height of the tree\n7.No of leaves\n8.Mirror image tree\n9.Copy Tree\n10.Find Node\n11.BFS" + 
                    "\n12.Bredth Of the tree\n13.Delete\n");
                Console.WriteLine("\nPlease enter the choice\n");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nPlease enter the element to be inserted in the tree\n");
                        data = int.Parse(Console.ReadLine());
                        tree.Insert(data);
                        break;
                    case 2:
                        Console.WriteLine("\nPre-order of the tree\n");
                        tree.PreOrder();
                        break;
                    case 3:
                        Console.WriteLine("\nIn-order of the tree\n");
                        tree.InOrder();
                        break;
                    case 4:
                        Console.WriteLine("\nPost-order of the tree\n");
                        tree.PostOrder();
                        break;
                    case 5:
                        Console.WriteLine(tree.NumOfNodes());
                        break;
                    case 6:
                        Console.WriteLine(tree.Height());
                        break;
                    case 7:
                        Console.WriteLine(tree.NumLeaves());
                        break;
                    case 8:
                        tree.MirrorImage();
                        break;
                    case 9:
                        Console.WriteLine("\nCopy of the tree\n");
                        tree.TreeCopy();
                        break;
                    case 10:
                        Console.WriteLine("\nPlease enter the element to be searched in the tree\n");
                        data = int.Parse(Console.ReadLine());
                        if (tree.FindNode(data)) { Console.WriteLine("Found"); } else { Console.WriteLine("Not Found"); }
                        break;
                    case 11:
                        Console.WriteLine("\nBFS of the tree\n");
                        tree.BFS();
                        break;
                    case 12:
                        Console.WriteLine("\nBreadth of the tree\n");
                        Console.WriteLine(tree.Breadth());
                        break;
                    case 13:
                        Console.WriteLine("\nPlease enter the element to be deleted in the tree\n");
                        data = int.Parse(Console.ReadLine());
                        if (tree.Delete(data)) { Console.WriteLine("Deleted"); } else { Console.WriteLine("Not Found To be Deleted"); }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nIn-order of the tree\n");
                tree.InOrder();
            }
            Console.ReadLine();
        }
    }
}
