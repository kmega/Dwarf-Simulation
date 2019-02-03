using System;

namespace TreeMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperations fileOp = new FileOperations();
            string path_1 = "t1.txt";
            string path_2 = "t4.txt";
            string[] tree_1 = fileOp.ReadFile(path_1);
            string[] tree_2 = fileOp.ReadFile(path_2);

            string[] tree = fileOp.MergeTrees(tree_1, tree_2);

            for (int i = 0; i < tree.Length; i++)
            {
                Console.WriteLine(tree[i]);
            }

            Console.ReadKey();
        }
    }
}
