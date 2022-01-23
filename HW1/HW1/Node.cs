using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class Node<T>
    {
        // Constructor allowing access to only the setter of the Data property.
        public Node(T newData)
        {
            Data = newData;
            LeftNode = null;
            RightNode = null;
        }

        // Constructor allowing access to the setter of all three properties.
        public Node(T newData, Node<T> leftNode, Node<T> rightNode)
        {
            Data = newData;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public Node<T> LeftNode { get; set; }

        public Node<T> RightNode { get; set; }

        public T Data { get; }

    }
}
