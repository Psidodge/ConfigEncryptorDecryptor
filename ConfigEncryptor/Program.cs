using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEncryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;

            if (args.Length == 0)
                path = GetFilePath();
            else
                path = args[0];

            Console.Write("1. Encrypt\n2. Decrypt\n");

            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Encrypt(path);
                    break;
                case ConsoleKey.D2:
                    Decrypt(path);
                    break;
            }
        }

        private static void Encrypt(string path)
        {
            string errorMsg;
            Encryptor.EncryptConnectionString(path, out errorMsg);
            if(errorMsg == null)
                Console.Write($"Config file of exe {path} was successfully encrypted.");
            else
                Console.Write($"An error has occurred.\nErro message: {errorMsg}");
            Console.ReadKey();
        }
        private static void Decrypt(string path)
        {
            string errorMsg;
            Decryptor.DecryptConnectionString(path, out errorMsg);
            if (errorMsg == null)
                Console.Write($"Config file of exe {path} was successfully decrypted.");
            else
                Console.Write($"An error has occurred.\nErro message: {errorMsg}");
            Console.ReadKey();
        }
        private static string GetFilePath()
        {
            string path;

            Console.Write("Enter path to the exe file: ");
            path = Console.ReadLine();
            return path;
        }
    }
}
