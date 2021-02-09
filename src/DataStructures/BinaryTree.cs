using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace DataStructure
{
    /// <summary>
    /// BST - tree like data structure where date is stored in ordered nodes
    /// Nodes sorted from top to bottom
    /// Left nodes less than a parent
    ///
    /// Killer feature O(log(n)), Insert/Find/Delete, Each step 1/2
    ///
    /// .NET SortedSet<T> - red-black tree
    /// .NET SortedDictionary<Tk, Tv> - BTS
    /// </summary>
    public class BinaryTree
    {
        
        //Root
        //left - right
        
        //full  - zero or two children
        //no full - no single nodes
        //perfect - all nodes have the same depth or level and 2 children. Family tree 
        //complete - all of its levels are completely filled
        // Degenerate or Pathological Tree - each one single child
        //Skewed Binary Tree - all of its internal nodes have exactly one child, and either left children or right children dominate the tree
        //balanced - minimum possible height (or depth)
            //difference of height between the left and the right subtrees for each node is at most one
        //unbalanced - h = (n + 1) / 2 - 1
        
        //How to search - How to traversal
        //Breadth First BFS -  from the left to right - level by level . Shortest Path
        //Deep first DFS    -  from top to bottom - row by row -
            //Inorder - L Root R - 2, 1, 3 (good if inherent order)
            //Preorder - Root L R, 1,2,3 (good for copying & expression trees)
            //Postorder - L R Root (used for deletions) 
            
        //pre order - ROOT, L, R
        //post order - L, R, Root

        //BFS - O(n), Space O(w), w- maximum width  
        //DFS - O(n), Space(h), h - maximum height / If recursion - function code overhead
        //Worst case 2^h
        //Height = O(logn) - balances, is tree is skewed O(n)
        //It is evident from above points that extra space required for Level order traversal is likely to be more when
        //tree is more balanced and extra space for Depth First Traversal is likely to be more when tree is less balanced.
        
        //BFS starts visiting nodes from root
        //DFS starts visiting nodes from leaves
        //If our problem is to search something that is more likely to closer to root, we would prefer BFS.
        //And if the target node is close to a leaf, we would prefer DFS
        //TOTAL Nodes - 2H - 1, H - height
        //TOTAL leafs - L + 1
        
        //O(logN) - insert, find, delete
        private Node Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public string Find(int key)
        {
            if (Root == null) return null;

            var node = Find(Root, key);

            return node?.Value;
        }

        //preorder 
        private static Node Find(Node node, int key)
        {
            if (node == null || node.Key == key) return node;

            if (key < node.Key) return Find(node.Left, key);
            if (key > node.Key) return Find(node.Right, key);

            return null;
        }

        //http://mishadoff.com/blog/dfs-on-binary-tree-array/
        
        public string Find_DFS(int key, ITestOutputHelper output)
        {
            var stack = new Stack<Node>();
            
            stack.Push(Root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                output.WriteLine($"{node.Key} == {key}");
                if (node.Key == key) return node.Value;
                if (node.Right != null) stack.Push(node.Right); //ORDER IS MATTER
                if (node.Left != null) stack.Push(node.Left);
            }

            return null;
        }
        
        public string Find_BFS(int key, ITestOutputHelper output)
        {
            var queue = new Queue<Node>();
            
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                output.WriteLine($"{node.Key} == {key}");
                if (node.Key == key) return node.Value;
                if (node.Right != null) queue.Enqueue(node.Right); //ORDER IS MATTER
                if (node.Left != null) queue.Enqueue(node.Left);
            }

            return null;
        }
        
        public void Insert(int key, string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value), "Can't have value equals to null");
            
            Node node = new Node(key, value);

            Root = Insert(Root, node);
        }

        private static Node Insert(Node parent, Node node)
        {
            if (parent == null)
            {
                return node;
            }
            
            if (node.Key < parent.Key)
            {
                parent.Left = Insert(parent.Left, node);
            }
            else
            {
                parent.Right = Insert(parent.Right, node);
            }

            return parent;
        }


        public string Min() => Root.Min().Value;
        public string Max() => Root.Max().Value;

        public void Delete(int key)
        {
            Root = Delete(Root, key);
        }

        private static Node Delete(Node parent, int key)
        {
            if (parent == null) return null;

            if (key < parent.Key)
            {
                parent.Left = Delete(parent.Left, key);
            }
            else if (key > parent.Key)
            {
                parent.Right = Delete(parent.Right, key);
            }
            else
            {
                //here the node we want to delete
                //Case 1: No child
                if (parent.Left == null && parent.Right == null)
                {
                    parent = null;
                }
                else if (parent.Left == null) //Case 2: One child
                {
                    parent = parent.Right;
                }
                else if (parent.Right == null) //Case 2: One child
                {
                    parent = parent.Left;
                }
                else //Case 3: Two children
                {
                    //Find the minimum in right node
                    Node minRight = parent.Right.Min();
                    

                    //Duplicate
                    parent.Duplicate(minRight.Key, minRight.Value);

                    //can be sub-tree
                    parent.Right = Delete(parent.Right, parent.Key);
                }
            }

            return parent;
        }


        //Inorder - L Root R   - inherid order ->
        //preorder - Root L R  - copy of a tree  top -> bottom
        //postorder - L R Root  - use in deletes - bottom -> top
        //DFS - traversing down through the subtrees (branch to the leaf)
        //Recursion function - save the call stack to grow
        
        //Alternative - use Stack to save the call stack
        public void TraversalDepthFirst_InOrder(ITestOutputHelper output)
        {
            TraversalDepthFirst_InOrder(Root, output);
        }

        public void TraversalDepthFirst_PreOrder(ITestOutputHelper output)
        {
            TraversalDepthFirst_PreOrder(Root, output);
        }
        
        public void TraversalDepthFirst_PostOrder(ITestOutputHelper output)
        {
            TraversalDepthFirst_PostOrder(Root, output);
        }
        
        private void TraversalDepthFirst_InOrder(Node parent, ITestOutputHelper output)
        {
            if (parent == null) return;
            
            TraversalDepthFirst_InOrder(parent.Left, output);
            output.WriteLine(parent.Key.ToString());
            TraversalDepthFirst_InOrder(parent.Right, output);
        }
        
        
        private void TraversalDepthFirst_PreOrder(Node parent, ITestOutputHelper output)
        {
            if (parent == null) return;
            
            output.WriteLine(parent.Key.ToString());
            TraversalDepthFirst_PreOrder(parent.Left, output);
            TraversalDepthFirst_PreOrder(parent.Right, output);
        }
        
        private void TraversalDepthFirst_PostOrder(Node parent, ITestOutputHelper output)
        {
            if (parent == null) return;
            
            TraversalDepthFirst_PostOrder(parent.Left, output);
            TraversalDepthFirst_PostOrder(parent.Right, output);
            output.WriteLine(parent.Key.ToString());
        }


        public void DFS_WithStack(ITestOutputHelper output)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                output.WriteLine(node.Key.ToString());
                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
        }
        
        
        //Traversing thought one level of children 
        //Then traverse throught the next level be level
       
        public void BreadthFirstTraversal(ITestOutputHelper output)
        {
            BreadthFirstTraversal(Root, output);
        }

        private void BreadthFirstTraversal(Node parent, ITestOutputHelper output)
        {
            
        }

        public void BFS_WithQueue(ITestOutputHelper output)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
                output.WriteLine(node.Key.ToString());
            }
        }


        public int Depth_BFS()
        {
            int level = 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
                level++;
            }

            return level;
        }

        public int Depth_DFS()
        {
            return Depth_DFS(Root);
        }


        private int Depth_DFS(Node node)
        {
            if (node == null) return -1;

            var left = Depth_DFS(node.Left);
            var right = Depth_DFS(node.Right);
            return Math.Max(left, right) + 1;

        }
        
        private class Node
        {
            public Node(int key, string value)
            {
                Key = key;
                Value = value;
            }
            
            public int Key { get; private set; }
            public string Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node Min()
            {
                if (Left == null)
                {
                    return this;
                }

                return Left.Min();
            }

            public Node Max()
            {
                if (Right == null)
                {
                    return this;
                }

                return Right.Max();
            }

            public void Duplicate(int minRightKey, string minRightValue)
            {
                Key = minRightKey;
                Value = minRightValue;
            }
        }


    }
}