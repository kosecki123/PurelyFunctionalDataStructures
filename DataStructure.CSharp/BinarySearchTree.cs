using System;
using System.ComponentModel.Design.Serialization;

namespace DataStructure.CSharp
{
    public class BinaryTree<T>
        where T : IComparable
    {
        public BinaryTree(T top)
        {
            this.Top = top;
        }

        public T Top { get; }

        public BinaryTree<T> Left { get; set; }

        public BinaryTree<T> Right { get; set; }
    }

    public static class BinarySearchTree
    {
        public static bool IsMember<T>(T element, BinaryTree<T> binaryTree) where T : IComparable
        {
            var t = binaryTree;
            while (t != null)
            {
                if (element.CompareTo(t.Top) < 0)
                {
                    t = t.Left;
                }
                else if (element.CompareTo(t.Top) > 0)
                {
                    t = t.Right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}