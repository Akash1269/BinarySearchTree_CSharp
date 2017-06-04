using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree_CSharp
{
    class Tree
    {
        public Node Root { get; set; }

        public bool Insert(int data)
        {
            Node node = new Node() { Data = data };
            if (Root == null)
                Root = node;
            bool inserted = false;
            Node temp = Root;
            while (!inserted)
            {
                if(data < temp.Data)
                {
                    if(temp.Left == null)
                    {
                        temp.Left = node;
                        inserted = true;
                    }
                    else
                    {
                        temp = temp.Left;
                    }
                }
                else if (data > temp.Data)
                {
                    if (temp.Right == null)
                    {
                        temp.Right = node;
                        inserted = true;
                    }
                    else
                    {
                        temp = temp.Right;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void Visit(Node node)
        {
            Console.Write(node.Data + " ");
        }

        public void PreOrder()
        {
            _PreOrder(Root);
        }

        void _PreOrder(Node node)
        {
            if (node != null)
            {
                Visit(node);
                _PreOrder(node.Left);
                _PreOrder(node.Right);
            }
        }

        public void InOrder()
        {
            _InOrder(Root);
        }


        void _InOrder(Node node)
        {
            if (node != null)
            {
                _InOrder(node.Left);
                Visit(node);
                _InOrder(node.Right);
            }
        }

        public void PostOrder()
        {
            _PostOrder(Root);
        }

        void _PostOrder(Node node)
        {
            if (node != null)
            {
                _PostOrder(node.Left);
                _PostOrder(node.Right);
                Visit(node);
            }
        }

        public int NumOfNodes()
        {
            return _NumOfNodes(Root);
        }

        int _NumOfNodes(Node node)
        {
            if (node == null)
                return 0;
            return _NumOfNodes(node.Left) + _NumOfNodes(node.Right) + 1;
        }

        public int Height()
        {
            return _Height(Root);
        }

        int _Height(Node node)
        {
            if (node == null)
                return -1;
            int leftHeight = _Height(node.Left);
            int RightHeight = _Height(node.Right);
            return (leftHeight > RightHeight ? leftHeight : RightHeight) + 1;
        }
        public int NumLeaves()
        {
            return _NumLeaves(Root);
        }

        int _NumLeaves(Node node)
        {
            if (node == null)
                return 0;
            if (node.Left == null && node.Right == null)
                return 1;
            return _NumLeaves(node.Left) + _NumLeaves(node.Right);
        }

        public void MirrorImage()
        {
            _MirrorImage(Root);
        }
        void _MirrorImage(Node node)
        {
            if (node != null)
            {
                Node temp = node.Left;
                node.Left = node.Right;
                node.Right = temp;
                _MirrorImage(node.Left);
                _MirrorImage(node.Right);
            }
        }

        public void TreeCopy()
        {
            Node newTree = _TreeCopy(Root);
            _InOrder(newTree);
        }
        Node _TreeCopy(Node node)
        {
            if (node != null)
                return new Node() { Data = node.Data, Left = _TreeCopy(node.Left), Right = _TreeCopy(node.Right) };
            else
                return null;
        }

        public bool FindNode(int data)
        {
            bool found = false;
            Node node = Root;
            while(node != null && !found)
            {
                if(data > node.Data)
                {
                    node = node.Right;
                }
                else if (data < node.Data)
                {
                    node = node.Left;
                }
                else
                {
                    found = true;
                }
            }
            return found;
        }

        public void BFS()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(Root);

            while(q.Count > 0)
            {
                Node node = q.Dequeue();
                Visit(node);
                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public int Breadth()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(Root);
            int max = 0;

            while (q.Count > 0)
            {
                if (max < q.Count)
                    max = q.Count;
                Node node = q.Dequeue();
                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
            return max;
        }

        public bool Delete(int data)
        {
            Node node = Root;
            Node prev = Root;
            bool deleted = false;
            Node newNode = null;

            while(node != null && !deleted)
            {
                if(data > node.Data)
                {
                    prev = node;
                    node = node.Right;                    
                }
                else if(data < node.Data)
                {
                    prev = node;
                    node = node.Left;
                }
                else
                {
                    DeleteNode(ref newNode, node);
                    deleted = true;
                    if (prev.Right != null && prev.Right.Data == node.Data)
                    {
                        prev.Right = newNode;
                    }
                    else
                    {
                        prev.Left = newNode;
                    }
                }
            }

            return deleted;
        }

        void DeleteNode(ref Node newNode, Node node)
        {            
            if(node.Left == null)
            {
                newNode = node.Right;                
            }
            else if (node.Right == null)
            {
                newNode = node.Left;
            }

            Case A: Where we pull out the right most node of left subtree of the node to be deleted as
             its the highest node just before current ndoe then point right tree to the right of that node
            else
            {
                Node temp = node.Left;
                while (temp.Right != null)
                {
                    temp = temp.Right;
                }
                temp.Right = node.Right;
                newNode = node.Left;
            }
            if (Root.Data == node.Data)
            {
                Root = node.Left;
            }

            //Case B: pull out the left most node of the right subtree of node to be deleted and point left subtree to the left
            // of that node, this element just next to current element
            //else
            //{
            //    Node temp = node.Right;
            //    while (temp.Left != null)
            //    {
            //        temp = temp.Left;
            //    }
            //    temp.Left = node.Left;
            //    newNode = node.Right;
            //}
            //if (Root.Data == node.Data)
            //{
            //    Root = node.Right;
            //}

            //Case C: find the right most element of left subtree of node to be deleted and then swap the values of
            // right most ndoe and node to be deleted, as we have found the replacement and then join left of that right most node
            // to right of its parent
        }
    }
}
