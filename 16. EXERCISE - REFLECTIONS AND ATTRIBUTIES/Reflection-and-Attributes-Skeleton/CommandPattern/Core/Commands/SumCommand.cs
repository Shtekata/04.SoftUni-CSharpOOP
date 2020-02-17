using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern.Core.Commands
{
    public class SumCommand : ICommand
    {
        public string Execute(string[] args)
        {
            var numbers = args.Select(int.Parse).ToArray();

            long sum = numbers.Sum(x => x);

            return $"Current sum: {sum}";
        }
    }
}
