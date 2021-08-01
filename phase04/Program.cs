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
