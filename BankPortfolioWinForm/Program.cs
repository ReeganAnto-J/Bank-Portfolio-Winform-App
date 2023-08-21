namespace BankPortfolioWinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static string balanceCsvLocation = @"../../../Data/Balance.csv";
        public static string detailsCsvLocation = @"../../../Data/Details.csv";
        public static string passwordCsvLocation = @"../../../Data/Password.csv";
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            GenerateDefultValues();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        static void GenerateDefultValues()
        {
            int iteration = 0;
            string[] filePaths = new string[3] { detailsCsvLocation, passwordCsvLocation, balanceCsvLocation};
            foreach (string path in filePaths)
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = new StreamWriter(path)) { };
                }
                if (new FileInfo(path).Length == 0)
                {
                    using (StreamWriter writer = new StreamWriter(path, true)) 
                    {
                        if (iteration == 0)
                        {
                            writer.WriteLine("1,ReeganAnto,21-10-2003");
                            writer.WriteLine("2,SriramL,03-9-2003");
                            writer.WriteLine("3,VishnuKumar,16-6-2003");
                            writer.WriteLine("4,JeswinSamuel,07-3-2003");
                            writer.WriteLine("5,SanjayP,17-2-2003");
                        }
                        else if (iteration == 1)
                        {
                            writer.WriteLine("1,0420");
                            writer.WriteLine("2,5414");
                            writer.WriteLine("3,1606");
                            writer.WriteLine("4,0703");
                            writer.WriteLine("5,1432");
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++) { writer.WriteLine("1,0"); }
                        }
                    };
                }
                iteration++;
            }
        }
    }
}