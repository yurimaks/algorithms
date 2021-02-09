using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode._101._110
{
    public class Task104
    {
        [Fact]
        public void Run()
        {
            var tree = new TreeNode(3, new TreeNode(2, new TreeNode(1)), new TreeNode(4));

            var depth = MaxDepth_Recursion(tree);
            Assert.Equal(3, depth);
        }

        public int MaxDepth_Recursion(TreeNode root)
        {
            if (root == null) return 0;
            return MaxDepth_Recursion(root, int.MinValue);
        }
    
        public int MaxDepth_Recursion(TreeNode root, int depth)
        {        
            if (root == null) return 1;
               
            int max1 = Math.Max(depth, Height(root.left));        
            return Math.Max(max1, Height(root.right));        
        }
    
        private static int Height(TreeNode node)
        {
            if (node == null) return 1;        
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }
        
        public int MaxDepth_DFS_Stack_NumberOfNodes(TreeNode root)
        {
            int max = int.MinValue;
            Stack<(TreeNode, int)> stack = new Stack<(TreeNode, int)>();
            stack.Push((root, 1));

            while (stack.Count > 0)
            {
                (TreeNode node, int h) Nd = stack.Pop();

                var node = Nd.node;

                max = Math.Max(max, Nd.h);

                if (node.right != null) stack.Push((node.right, Nd.h + 1));
                if (node.left != null) stack.Push((node.left, Nd.h + 1));
            }

            return max;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}