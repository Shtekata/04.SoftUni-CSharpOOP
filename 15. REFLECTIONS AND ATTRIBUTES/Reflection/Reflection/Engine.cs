using System;
using System.Text;

namespace Reflection
{
    public class Engine
    {
        public void Run()
        {
            //var sb = Type.GetType("System.Int");
            var sbType = Type.GetType("System.Text.StringBuilder");
            var sbInstance = (StringBuilder)Activator.CreateInstance(sbType);
            var sbInstCapacity = (StringBuilder)Activator.CreateInstance(sbType, new object[] { 10 });



        }
    }
}
