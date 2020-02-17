using Logger.Exeptions;
using Logger.Models.Contracts;
using Logger.Models.Layouts;
using System;
using System.Linq;
using System.Reflection;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        //public ILayout GetLayout(string type)
        //{
        //    ILayout layout;
        //
        //    if (type == "SimpleLayout")
        //    {
        //        layout = new SimpleLayout();
        //    }
        //    else if (type == "XmlLayout")
        //    {
        //        layout = new XmlLayout();
        //    }
        //    else
        //    {
        //        throw new InvalidLayoutTypeException();
        //    }
        //
        //    return layout;
        //}

        public ILayout GetLayout(string type)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type typeToCreate = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            if (typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            var layout = (ILayout)Activator.CreateInstance(typeToCreate);

            return layout;
        }
    }
}
