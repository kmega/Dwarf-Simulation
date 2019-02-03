using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreeMerge;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void GetDepthOfEachLine()
        {
            //given
            FileOperations fileOp = new FileOperations();
            string path_1 = "t1.txt";
            string path_2 = "t2.txt";
            string[] tree_1 = fileOp.ReadFile(path_1);
            string[] tree_2 = fileOp.ReadFile(path_2);

            //when
            List<int> tree_1_Depth = fileOp.GetDepth(tree_1.ToList());
            List<int> tree_2_Depth = fileOp.GetDepth(tree_2.ToList());

            //then
            Assert.AreEqual(0, tree_1_Depth[0]);
            Assert.IsTrue(tree_1_Depth[0] < tree_1_Depth[1]);
            Assert.IsTrue(tree_1_Depth[5] == tree_1_Depth[7]);
        }

       

        //[Test]
        //public void WhiteSpaceCounter()
        //{
        //    //given
        //    FileOperations whiteSpaces = new FileOperations();
        //    string[] array_1 = { "a", "b", "c", "c_1", "c_2", "d", "e" };
        //    string[] array_2 = { "a", "b", "b_1", "c", "c_1", "c_3" };

        //    //whiteSpaces.GetDepth(); //Here to finish
        //}

        //[Test]
        //public void SortArrayByNameOfBranch()
        //{
        //    //given
        //    FileOperations merge = new FileOperations();
        //    ClearTree makeTree = new ClearTree();
        //    string[] array_1 = { "a", "b", "c", "c_1", "c_2", "d", "e" };
        //    string[] array_2 = { "a", "b", "b_1", "c", "c_1", "c_3" };


        //    //when, then
        //    string[] result = makeTree.SortTree(array_1, array_2);

        //    Assert.AreEqual("a", result[0]);
        //    Assert.AreEqual("b", result[1]);
        //    Assert.AreEqual("b_1", result[2]);
        //    Assert.AreEqual("c", result[3]);
        //}
    }
}