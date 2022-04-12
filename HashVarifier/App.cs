using System.Security.Cryptography;

namespace HashVarifier;

internal class App
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("<==================== Hash Varifier ====================>");
        Console.WriteLine("***** Coded with <3 by Evilprince2009 *****");
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Select what you want to do.");
            Console.WriteLine("1. Calculate file HASH");
            Console.WriteLine("2. Match HASHes to verify files");
            Console.ForegroundColor = ConsoleColor.White;
            string decission = Console.ReadLine()!.Trim();
            if (decission == "1")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter full path with file name.");
                string filepath = Console.ReadLine()!.Trim();
                TimeLapse(500, 5);
                Console.WriteLine("Calculated HASH");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(GenerateHash(filepath));
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (decission == "2")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter full path with name for first file");
                string first = Console.ReadLine()!.Trim();
                Console.WriteLine("Enter full path with name for second file");
                string second = Console.ReadLine()!.Trim();

                if (String.Compare(GenerateHash(first), GenerateHash(second), StringComparison.Ordinal) == 0)
                {
                    TimeLapse(500, 5);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("=> File HASHes match");
                }
                else
                {
                    TimeLapse(500, 5);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=> File HASHes do not match");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=> Choose a valid option . . .");
            }
        }
    }

    private static void TimeLapse(int millis, int times)
    {
        Console.WriteLine("Hang on just a moment");
        for (int i = 0; i < times; i++)
        {
            Thread.Sleep(millis);
            Console.Write(". ");
        }
        Console.WriteLine(Environment.NewLine);
    }
    private static string GenerateHash(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("Something unusual happened", filename);
        }
        else
        {
            var algorithm = SHA256.Create();
            using FileStream stream = new(filename, FileMode.Open, FileAccess.ReadWrite);
            byte[] hashes = algorithm.ComputeHash(stream);
            return BitConverter.ToString(hashes).Replace("-", "").ToLowerInvariant();
        }
    }
}
