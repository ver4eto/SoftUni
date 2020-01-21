using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmty()
        {
            return this.Count == 0;
        }

        public void AddRange(Stack<string> collection)
        {            
            foreach (var str in collection)
            {
                this.Push(str);
            }
        }
    }
}
