using System;
using Xunit;

namespace LeetCode._101._110
{
    public class Task110
    {
        [Fact]
        public void Run()
        {
            var tree = new TreeNode(3, new TreeNode(2, new TreeNode(1, new TreeNode(2))), new TreeNode(4));

            var isBalanced = IsBalanced(tree);
            Assert.False(isBalanced);
            
        }
        
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
        
            int lh = Height(root.left);
            int rh = Height(root.right);
        
            int diff = Math.Abs(lh - rh);
            if (diff > 1) return false;
        
            return IsBalanced(root.left) && IsBalanced(root.right);
        
        }
    
        private static int Height(TreeNode node)
        {
            if (node == null) return 0;
        
            return 1 + Math.Max(Height(node.left), Height(node.right));
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