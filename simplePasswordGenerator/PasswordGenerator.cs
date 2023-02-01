using System;

namespace simplePasswordGenerator
{
    public class PasswordGenerator
    {
        public string includedChars(string question, string characters)
        {
            Console.WriteLine(question);
            string returnValue = "";
            while (true)
            {
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "y":
                        returnValue = characters;
                        break;
                    case "n":
                        returnValue = "";
                        break;
                    default:
                        Console.WriteLine("Please answer like y/n");
                        continue;
                }
                return returnValue;
            }
        }

        public string createPassword(int length, string chosenChars){
            string password = "";
            for (int i = 0; i < length; i++)
            {
                Random random = new Random();
                password += chosenChars[random.Next(0, chosenChars.Length)];
            }
            return password;
        }
        
    }
}

