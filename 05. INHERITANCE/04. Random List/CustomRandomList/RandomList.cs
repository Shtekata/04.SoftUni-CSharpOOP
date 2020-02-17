using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd => new Random();
        public string RandomString()
        {
            var index = rnd.Next(Count);
            var element = this[index];
            RemoveAt(index);
            return element;
        }
    }
}
