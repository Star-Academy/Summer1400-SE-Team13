using System;
using System.IO;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace phase04
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoresOrganizer organizer = new ScoresOrganizer();

            FileReader fileReader = new FileReader();
            DataManager dataManager = new DataManager();
            
            organizer.Run(fileReader, dataManager);
        }
    }
}
