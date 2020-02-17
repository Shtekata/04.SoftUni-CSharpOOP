using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            var className = $"{GetType().Namespace}.{investigatedClass}";
            var classType = Type.GetType(className);
            var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            var stringBuilder = new StringBuilder();

            var classInstance = Activator.CreateInstance(classType, new object[] { });

            stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

            var targetFields = classFields.Where(x => requestedFields.Contains(x.Name));

            foreach (var item in targetFields)
            {
                stringBuilder.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }
        public string AnalizeAcessModifiers(string className)
        {
            var classType = Type.GetType($"{GetType().Namespace}.{className}");
            var classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            var classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var stringBuilder = new StringBuilder();

            foreach (var item in classFields)
            {
                stringBuilder.AppendLine($"{item.Name} must be private!");
            }

            foreach (var item in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{item.Name} have to be public!");
            }

            foreach (var item in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{item.Name} have to be private!");
            }

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string investigatedClass)
        {
            var classType = Type.GetType($"{GetType().Namespace}.{investigatedClass}");
            var classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methods of Class: {investigatedClass}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var item in classMethods)
            {
                stringBuilder.AppendLine(item.Name);
            }

            return stringBuilder.ToString().Trim();
        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            var classType = Type.GetType($"{GetType().Namespace}.{investigatedClass}");
            var classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var stringBuilder = new StringBuilder();

            foreach (var item in classMethods.Where(x => x.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{item.Name} will return {item.ReturnType}");
            }

            foreach (var item in classMethods.Where(x => x.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
