using System;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Factories
{
    public class JSONLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            var sb = new StringBuilder();

            sb.AppendLine("\"log\":[")
                .AppendLine("\t\"date\":\"{0}\",")
                .AppendLine("\t\"level\":\"{1}\",")
                .AppendLine("\t\"message\":\"{2}\"")
                .AppendLine("]");

            return sb.ToString().TrimEnd();
        }
    }
}
