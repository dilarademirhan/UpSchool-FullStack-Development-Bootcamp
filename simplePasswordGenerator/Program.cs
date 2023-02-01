using simplePasswordGenerator;

Console.WriteLine("**********************************************\n" 
                  + "Welcome to the B E S T P A S S W O R D M A N A G E R !\n"
                  + "************************************************\n");

string numbers = "0123456789";
string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string lowercase = "abcdefghijklmnopqrstuvwxyz";
string special = "~`!@#$%^&*()_-+={[}]|:;\"'<,>.?/";
string chosenChars = "";

string includeNumbers = "Do you want to include numbers?";
string includeLowercase = "OK! How about lowercase characters?";
string includeUppercase = "Very nice! How about uppercase characters?";
string includeSpecial = "All right! We are almost done. Would you also want to add special characters?";

PasswordGenerator p = new PasswordGenerator();
chosenChars += p.includedChars(includeNumbers, numbers);
chosenChars += p.includedChars(includeLowercase, lowercase);
chosenChars += p.includedChars(includeUppercase, uppercase);
chosenChars += p.includedChars(includeSpecial, special);

int passwordLength = 0;
while(true){
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

Console.WriteLine("\n-------------------------------------------------\n" 
                  + p.createPassword(passwordLength, chosenChars)
                  + "\n-------------------------------------------------\n");
