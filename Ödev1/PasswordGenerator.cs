using System;

namespace simplePasswordGenerator
{
    public class PasswordGenerator
    {
        public string includedChars(string question, string characters)
        {
            Console.WriteLine(question);
            string includedChars = "";
            while (true)
            {
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "y":
                        includedChars = characters;
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine("Please answer like y/n");
                        continue;
                }
                return includedChars;
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
                    while(passwordLength <= 0){
                        Console.WriteLine("Please enter a positive nunmber.");
                        passwordLength = Int32.Parse(Console.ReadLine());
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
            return passwordLength;
        }

        public void printPassword(string chosenChars){
            Console.WriteLine("\n-------------------------------------------------\n" 
                              + createPassword(passwordLength(), chosenChars)
                              + "\n-------------------------------------------------\n");
        }
    }
}

