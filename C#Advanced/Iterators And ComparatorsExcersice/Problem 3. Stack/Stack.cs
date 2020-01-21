namespace p03._01.Stack
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Stack<T> : IEnumerable<T>
    {
        private IList<T> stack;

        public Stack()
        {
            this.stack = new List<T>();
        }

        public void Push(params T[] arguments)
        {
            foreach (var element in arguments)
            {
                this.stack.Add(element);
            }
        }

        public void Pop()
        {
            if (this.stack.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            this.stack.RemoveAt(this.stack.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
