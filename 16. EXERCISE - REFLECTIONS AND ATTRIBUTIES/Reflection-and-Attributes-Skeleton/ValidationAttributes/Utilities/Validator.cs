using System.Linq;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var propertyInfos = obj.GetType().GetProperties();

            foreach (var item in propertyInfos)
            {
                var attributes = item
                    .GetCustomAttributes(false)
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var item2 in attributes)
                {
                    if (!item2.IsValid(item.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
