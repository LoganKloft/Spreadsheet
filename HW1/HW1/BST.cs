using System;
using System.Collections.Generic;
using System.Text;

// The return type used in the Insert(T data) method.
enum InsertState
{
    Success, // Type T successfully inserted into the BST
    Duplicate // Type T is already in the BST
}

namespace HW1
{
    class BST<T>
    {
        // The top-level node of the BST
        private Node<T> root;

        // Inserts data of type T into the BST as long as T is comparable and not a duplicate.
        // Returns InsertState.Duplicate in case of a duplicate data value, and InsertState.Success otherwise.
        public InsertState Insert(T data)
        {
        }

        // Returns the number of items stored in the BST.
        // Uses inorder traversal
        public int Count(Node<T> treeNode = root)
        {
        }

        // Uses inorder traversal to display the values stored in the BST in ascending order.
        // Type T must be printable.
        public void Display(Node<T> treeNode = root)
        {
        }

        // Returns the height of the BST + 1.
        public int Levels(Node<T> treeNode = root)
        {
        }

        // Returns the least amount of levels the BST can have with its current Count.
        public int MinimumLevels()
        {
        }
    }
}
