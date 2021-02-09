using Xunit;
using Xunit.Abstractions;

namespace DataStructure
{
    public class BinaryTreeTests
    {
        private readonly ITestOutputHelper _output;
        
        private readonly BinaryTree tree;
        public BinaryTreeTests(ITestOutputHelper output)
        {
            _output = output;
            tree = new BinaryTree();
        }

        [Fact]
        public void InsertTest()
        {
            tree.Insert(3, "a");
            tree.Insert(2, "b");
            tree.Insert(4, "c");
        }
        
        
        [Fact]
        public void FindTest()
        {
           //  tree.Insert(3, "a");
           //  tree.Insert(2, "b");
           //  tree.Insert(4, "c");
           //
           // Assert.Equal("c", tree.Find(4));
           // Assert.Equal("a", tree.Find(3));
           // Assert.Equal("b", tree.Find(2));

           tree.Insert(5, "a");
           tree.Insert(3, "b");
           tree.Insert(2, "c");
           tree.Insert(1, "c");
           tree.Insert(4, "c");

           Assert.Equal("c", tree.Find(1));
        }
        
        [Fact]
        public void FindMinTest()
        {
            tree.Insert(5, "a");
            tree.Insert(3, "b");
            tree.Insert(2, "c");
            tree.Insert(1, "c");
            tree.Insert(4, "c");

            Assert.Equal("c", tree.Min());
        }
        
        [Fact]
        public void FindMaxTest()
        {
            tree.Insert(5, "a");
            tree.Insert(3, "b");
            tree.Insert(2, "c");
            tree.Insert(1, "c");
            tree.Insert(4, "c");
            tree.Insert(6, "c");
            tree.Insert(7, "z");
            
            Assert.Equal("z", tree.Max());
        }


        [Fact]
        public void DeleteNoChild()
        {
            //simple reference null
            tree.Insert(5, "a");
            tree.Insert(3, "b");
            
            tree.Delete(3);

            Assert.Null(tree.Find(3));
        }
        
        [Fact]
        public void DeleteOneChild()
        {
            //target node 
            //replace with target with child
            //remove child
            tree.Insert(5, "a");
            tree.Insert(3, "b");
            
            tree.Delete(5);

            Assert.Null(tree.Find(5));
        }
        
        [Fact]
        public void DeleteTwoChildren()
        {
            //find the node want to delete
            //in RIGHT sub-tree find the minimum
            //copy min with target node
            //remove node
            SetupTheTree();
            
            
            tree.Delete(7);

            Assert.Null(tree.Find(7));
        }

        [Fact]
        public void InOrderTraversal()
        {
            SetupTheTree();
            
            tree.TraversalDepthFirst_InOrder(_output);
        }
        
        [Fact]
        public void PreOrderTraversal()
        {
            SetupTheTree();
            
            tree.TraversalDepthFirst_PreOrder(_output);
        }
        
        [Fact]
        public void PostOrderTraversal()
        {
            SetupTheTree();
            
            tree.TraversalDepthFirst_PostOrder(_output);
        }

        [Fact]
        public void BreadthFirstTraversalTest()
        {
            SetupTheTree();

            tree.BreadthFirstTraversal(_output);
        }
        
        [Fact]
        public void DFS_WithStackTest()
        {
            SetupTheTree();

            tree.DFS_WithStack(_output);
        }
        
        [Fact]
        public void BFS_WithQueueTest()
        {
            SetupTheTree();

            tree.BFS_WithQueue(_output);
        }
        
        [Fact]
        public void BFS_WithQueueFindTest()
        {
            SetupTheTree();

            Assert.Equal("i", tree.Find_BFS(8, _output));
        }
        
        [Fact]
        public void DFS_WithStackFindTest()
        {
            SetupTheTree();

            Assert.Equal("b", tree.Find_DFS(6, _output));
        }

        [Fact]
        public void Depth_DFSTest()
        {
            SetupTheTree();

            Assert.Equal(2, tree.Depth_DFS());
            
            tree.Insert(2, "p");
            tree.Insert(1, "p");
            
            Assert.Equal(3, tree.Depth_DFS());
        }
        
        [Fact]
        public void Depth_BFSTest()
        {
            SetupTheTree();

            Assert.Equal(2, tree.Depth_DFS());
            
            tree.Insert(2, "p");
            tree.Insert(1, "p");
            
            Assert.Equal(3, tree.Depth_DFS());
        }
        
        private void SetupTheTree()
        {
            tree.Insert(5, "a");
            tree.Insert(3, "b");
            tree.Insert(7, "b");
            tree.Insert(6, "b");
            tree.Insert(8, "i");
            tree.Insert(2, "p");
        }
    }
}