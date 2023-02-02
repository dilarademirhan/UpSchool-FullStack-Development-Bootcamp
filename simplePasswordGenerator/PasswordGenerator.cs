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
        
        public int passwordLength()
        {
            int passwordLength = 0;
            while (true)
            {
                Console.WriteLine("Great! Lastly. How long do you want to keep your password length?");
                try
                {
                    passwordLength = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
            return passwordLength;
        }
    }
}

