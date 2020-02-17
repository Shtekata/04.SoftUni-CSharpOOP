using System;
using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            ParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; set; }

        public void CompleteMission()
        {
            if (State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            State = State.Finished;
        }

        private void ParseState(string stateStr)
        {
            State state;

            bool parsed = Enum.TryParse<State>(stateStr, out state);

            if (!parsed)
            {
                throw new InvalidStateException();
            }

            State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
