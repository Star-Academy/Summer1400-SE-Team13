using System;
using System.Collections.Generic;
using System.Linq;
using Phase5.Interface;

namespace Phase5
{
    public class IOHandler : IIOHandler
    {
         public string GetUserInput()
         {
             Console.WriteLine("Enter the input!");
             return Console.ReadLine();
         }
        
         public void PrintCommandResult(HashSet<string> commandResult)
         {
             if (!commandResult.Any())
             {
                 Console.WriteLine("No doc found!");
             }
             else
             {
                 Console.WriteLine("Total number of match: " + commandResult.Count);
                 Console.WriteLine("Docs: " + string.Join(",", commandResult));
             }
         }
    }
}
