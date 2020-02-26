using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_06
{
    class Program
    {
        static readonly string pathToSourceFile = "../../phones.txt";
        static readonly string pathToNewFile = "../../New.txt";

        static void Main(string[] args)
        {
            // Task A
            Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

            // Task A-1
            StreamReader fileReader = new StreamReader(pathToSourceFile);

            string line;
            while ((line = fileReader.ReadLine()) != null && PhoneBook.Count != 9)
            {
                string[] parts = line.Split(':');

                string personName = parts[0];
                string personPhoneNumber = parts[1];

                PhoneBook.Add(personName, personPhoneNumber);
            }

            fileReader.Close();

            // Clean file
            File.WriteAllText(pathToSourceFile, string.Empty);

            // Write only phones to file 
            StreamWriter fileWriter = new StreamWriter(pathToSourceFile);

            foreach (KeyValuePair<string, string> item in PhoneBook)
            {
                fileWriter.WriteLine(item.Value);
            }

            fileWriter.Close();

            // Task A-2
            Console.Write("Enter person name: ");
            string name = Console.ReadLine();

            if (PhoneBook.TryGetValue(name, out string phoneNumber))
            {
                Console.WriteLine(phoneNumber);
            }
            else
            {
                Console.WriteLine("There is no such person in the phone book");
            }

            // Task A-3
            StreamWriter newFileWriter = new StreamWriter(pathToNewFile);

            foreach (KeyValuePair<string, string> item in PhoneBook)
            {
                if (item.Value.IndexOf("+380") == 0)
                {
                    newFileWriter.WriteLine(item.Value);
                }
                else
                {
                    newFileWriter.WriteLine($"+3{item.Value}");
                }
            }

            newFileWriter.Close();

            // Task B
            List<int> listOfNumbers = new List<int>() { 1 };

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    listOfNumbers.Add(ReadNumber(listOfNumbers[i], 100));
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    break;
                }
            }

            Console.WriteLine("Done!");

            Method1();

            Console.ReadLine();
        }

        static int ReadNumber(int start, int end)
        {
            Console.Write($"Please enter integer number between {start} and {end}: ");

            string userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int intUserNumber) && intUserNumber > start && intUserNumber < end)
            {
                return intUserNumber;
            }
            else
            {
                throw new Exception("Input is not valid");
            }
        }

        static void Method1()
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                string key = "bla-bla";

                Console.WriteLine(dictionary[key]);
            }
            catch (Exception error)
            {
                Console.WriteLine($"Method 1 exception: {error.Message}");
                Method2();
            }
        }

        static void Method2()
        {
            try
            {
                Method3();
            }
            catch (Exception error)
            {
                Console.WriteLine($"Method 2 exception: {error.Message}");
            }
        }

        static void Method3()
        {
            try
            {
                int num = 0;
                Console.WriteLine($"Some operation {5 / num}");
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
