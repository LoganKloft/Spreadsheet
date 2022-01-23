using System;
using System.Collections.Generic;
using System.Text;

// The return type used in the Insert(T data) method.
enum InsertState
{
    Success, // Type T successfully inserted into the BST.
    Duplicate // Type T is already in the BST.
}

namespace HW1
{
    // IComparable so can use equivalent of '<' and '>' in the form of CompareTo.
    class BST<T> where T:IComparable
    {
        // The top-level node of the BST.
        private Node<T> _root;

        public BST()
        {
            _root = null;
        }

        // Inserts data of type T into the BST as long as T is comparable and not a duplicate.
        // Returns InsertState.Duplicate in case of a duplicate data value, and InsertState.Success otherwise.
        public InsertState Insert(T data)
        {
            if(_root == null)
            {
                _root = new Node<T>(data);
                return InsertState.Success;
            }

            return InsertHelper(data, _root);
        }

        private InsertState InsertHelper(T data, Node<T> treeNode)
        {
            if(data.CompareTo(treeNode.Data) < 0) // left sub-tree
            {
                if (treeNode.LeftNode == null)
                {
                    treeNode.LeftNode = new Node<T>(data);
                    return InsertState.Success;
                }
                else
                {
                    return InsertHelper(data, treeNode.LeftNode);
                }
            } else if(data.CompareTo(treeNode.Data) > 0) // right sub-tree
            {
                if(treeNode.RightNode == null)
                {
                    treeNode.RightNode = new Node<T>(data);
                    return InsertState.Success;
                } else 
                {
                    return InsertHelper(data, treeNode.RightNode);
                }
            }

            return InsertState.Duplicate; // found duplicate
        }

        // Returns the number of items stored in the BST.
        public int Count()
        {
            return CountHelper(_root);
        }

        public int CountHelper(Node<T> treeNode)
        {
            if (treeNode == null) return 0;
            return 1 + CountHelper(treeNode.LeftNode) + CountHelper(treeNode.RightNode);
        }

        // Uses inorder traversal to display the values stored in the BST in ascending order.
        // Type T must be printable.
        public void Display()
        {
            DisplayHelper(_root);
        }

        public void DisplayHelper(Node<T> treeNode)
        {
            if (treeNode == null) return;
            DisplayHelper(treeNode.LeftNode);
            System.Console.Write(treeNode.Data + " ");
            DisplayHelper(treeNode.RightNode);
        }

        // Returns the height of the BST + 1.
        public int Levels()
        {
            return LevelsHelper(_root);
        }

        public int LevelsHelper(Node<T> treeNode)
        {
            if (treeNode == null) return 0;
            return Math.Max(LevelsHelper(treeNode.LeftNode), LevelsHelper(treeNode.RightNode)) + 1;
        }

        // Returns the least amount of levels the BST can have with its current Count.
        public int MinimumLevels()
        {
            int count = this.Count();
            if (count == 0) return 0;
            return (int) Math.Log2(count) + 1;
        }
    }
}
