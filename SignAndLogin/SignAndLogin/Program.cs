using System.Net.Http.Headers;
using System.Runtime;

namespace SignAndLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            Console.WriteLine("Welcome to our app");
            Console.ReadKey();
            DisplayOption();
        }
        
        static void DisplayOption()
        {
            Console.Clear();
            Console.WriteLine("[1]-Sign in       ||       [2]-Login in");
            Console.WriteLine("          [0]-Close app");
            ChooseOption();
        }
        static void ChooseOption()
        {
            int operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1: Sign(); break;
                case 2: Login(); break;
                case 3: CloseApp(); break;
                default: Console.Clear();
                    Console.WriteLine("Choose correct operation!");
                    Console.ReadKey();
                    DisplayOption(); break;
            }
        }
        static void CloseApp()
        {
            Console.Clear();
            string path = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = Directory.GetParent(path);
            var parentDirectory = directoryInfo.Parent.Parent.Parent;

            var signFile = $"{parentDirectory}\\Sign.txt";

            if (File.Exists(signFile))
            {
                File.Delete(signFile);
            }

            Console.WriteLine("Thank you for using our app");
            Console.ReadKey();
        }
        static void Sign()
        {
            Console.Clear();
            Console.WriteLine("--- Sign in ---");
            Console.Write("Fullname: ");
            string fullName = Console.ReadLine();
            Console.Write("User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();

            string path = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = Directory.GetParent(path);
            var parentDirectory = directoryInfo.Parent.Parent.Parent;

            var signFile = $"{parentDirectory}\\Sign.txt";

            if (!File.Exists(signFile))
            {
                File.Create(signFile).Close();
            }

            string fileText = File.ReadAllText(signFile);

            if (fileText.Contains(userName) && fileText.Contains(password))
            {
                Console.Clear();
                Console.WriteLine("This account is already signed!");
                Console.ReadKey();
                DisplayOption();
            }
            else if (fileText.Contains(userName))
            {
                Console.Clear();
                Console.WriteLine("This user name is already used, \n" +
                    "Please choose another user name");
                Console.ReadKey();
                Sign();
            }
            else
            {
                Console.Clear();
                int i = 1;
                File.AppendAllText(signFile, $"--- {i} User`s informations ---\n" +
                    $"Fullname: {fullName}\n" +
                    $"User name: {userName}\n" +
                    $"Password: {password}\n" +
                    $"Phone number: {phoneNumber}\n\n");
                i++;

                Console.WriteLine("You successfully sign in!");
                Console.ReadKey();
                DisplayOption();
            }
        }
        static void Login()
        {
            Console.Clear();
            Console.WriteLine("--- Login ---");
            Console.Write("User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            string path = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = Directory.GetParent(path);
            var parentDirectory = directoryInfo.Parent.Parent.Parent;

            var signFile = $"{parentDirectory}\\Sign.txt";

            string fileText = File.ReadAllText(signFile);

            if (fileText.Contains(userName) && fileText.Contains(password))
            {
                Console.Clear();
                string fileContents = File.ReadAllText(signFile);
                Console.WriteLine(fileContents);
                Console.ReadKey();
                DisplayOption();
            }
            else if (fileText.Contains(userName))
            {
                Console.Clear();
                Console.WriteLine("Password entered false, \n" +
                    "please try again");
                Console.ReadKey();
                Login();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Such a user does not exist,\nplease sign in first");
                Console.ReadKey();
                Sign();
            }
        }
    }
}