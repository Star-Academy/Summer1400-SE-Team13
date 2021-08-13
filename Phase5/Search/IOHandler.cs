using System;
using System.Collections.Generic;
using System.Linq;

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
                 Console.WriteLine("No do found!");
             }
             else
             {
                 Console.WriteLine("Total number of match: " + commandResult.Count);
                 Console.WriteLine("Docs: " + string.Join(",", commandResult));
             }
         }
    }
}