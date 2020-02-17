using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }
        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                Push(item);
            }

            return this;
        }
    }
}
