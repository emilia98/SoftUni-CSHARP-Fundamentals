using System.Collections.Generic;

namespace TheTankGame.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string ProcessInput(List<string> inputParameters);
    }
}