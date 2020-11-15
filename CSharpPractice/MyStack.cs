using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice
{
    class MyStack
    {
        private Node _head;

        public MyStack() { _head = null; }

        public void Push(char val)
        {
            Node p = new Node(val);
            p.Next = _head;
            _head = p;
        }

        public char Pop()
        {
            if(_head != null)
            {
                char c = _head.Val;
                _head = _head.Next;
                return c;
            }
            return '\0';
        }

        private class Node
        {
            public char Val;
            public Node Next;
            public Node(char val)
            {
                Val = val;
            }

        }

    }
}
