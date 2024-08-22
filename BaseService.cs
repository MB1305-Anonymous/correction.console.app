namespace correction.console.bll;

public class BaseService
{
    public static void NumberGuessingGame()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101); // Generates a random number between 1 and 100
        int guess;
        int attempts = 0;
        bool guessedCorrectly = false;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I have selected a number between 1 and 100. Try to guess it.");

        while (!guessedCorrectly)
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            attempts++;
            secretNumber = 60;

            if (guess < secretNumber)
            {
                Console.WriteLine(" That's Lower! Try again.");
            }
            else if (guess > secretNumber)
            {
                Console.WriteLine("That's Higher! Try again.");
            }
            else
            {
                guessedCorrectly = true;
                Console.WriteLine(
                    $"Congratulations! You've guessed the number {secretNumber} correctly in {attempts} attempts.");
            }
        }
    }




    public static void PalindromeChecker()
    {
        Console.WriteLine("Palindrome Checker");
        Console.WriteLine("Enter a word or phrase to check (or type 'exit' to quit):");

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (IsPalindrome(input))
            {
                Console.WriteLine($"\"{input}\" is a palindrome.");
            }
            else
            {
                Console.WriteLine($"\"{input}\" is not a palindrome.");
            }
        }
    }

    static bool IsPalindrome(string input)
    {
        // Remove non-alphanumeric characters and convert to lowercase
        string cleanedInput = System.Text.RegularExpressions.Regex.Replace(input, "[^A-Za-z0-9]", "").ToLower();

        int left = 0;
        int right = cleanedInput.Length - 1;

        while (left < right)
        {
            if (cleanedInput[left] != cleanedInput[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    public static void SimpleCalculator()
    {
        while (true)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            Console.Write("Select an operation (1-5): ");

            string operation = Console.ReadLine();
            if (operation == "5")
            {
                break;
            }

            double num1, num2;
            try
            {
                Console.Write("Enter first number: ");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter second number: ");
                num2 = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number input. Please enter valid numbers.");
                continue;
            }

            double result = 0;
            bool validOperation = true;

            switch (operation)
            {
                case "1":
                    result = num1 + num2;
                    break;
                case "2":
                    result = num1 - num2;
                    break;
                case "3":
                    result = num1 * num2;
                    break;
                case "4":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        validOperation = false;
                    }
                    else
                    {
                        result = num1 / num2;
                    }

                    break;
                default:
                    Console.WriteLine("Invalid operation selected.");
                    validOperation = false;
                    break;
            }

            if (validOperation)
            {
                Console.WriteLine("Result: " + result);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static void FileWordCounter()
    {
        // Path to the text file
        string filePath = @"C:\Users\DELL\Documents\JANE ASSIGNMENT.docx";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }

        // Read the file content
        string text = File.ReadAllText(filePath);

        // Split the text into words
        var words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries);

        // Dictionary to hold word counts
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        // Count each word
        foreach (var word in words)
        {
            string lowerWord = word.ToLower(); // Convert to lowercase to ensure case-insensitive counting
            if (wordCounts.ContainsKey(lowerWord))
            {
                wordCounts[lowerWord]++;
            }
            else
            {
                wordCounts[lowerWord] = 1;
            }
        }

        // Get the top 10 most frequent words
        var topWords = wordCounts.OrderByDescending(pair => pair.Value).Take(10);

        // Display the top 10 words
        Console.WriteLine("Top 10 most frequent words:");
        foreach (var pair in topWords)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }


    public static void TemperatureCounter()
    {
        while (true)
        {
            Console.WriteLine("Temperature Converter");
            Console.WriteLine("1. Celsius to Fahrenheit");
            Console.WriteLine("2. Fahrenheit to Celsius");
            Console.WriteLine("3. Celsius to Kelvin");
            Console.WriteLine("4. Kelvin to Celsius");
            Console.WriteLine("5. Fahrenheit to Kelvin");
            Console.WriteLine("6. Kelvin to Fahrenheit");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 7)
            {
                break;
            }

            double temperature = 0;
            switch (choice)
            {
                case 1:
                    Console.Write("Enter temperature in Celsius: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Fahrenheit: {CelsiusToFahrenheit(temperature)}");
                    break;
                case 2:
                    Console.Write("Enter temperature in Fahrenheit: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Celsius: {FahrenheitToCelsius(temperature)}");
                    break;
                case 3:
                    Console.Write("Enter temperature in Celsius: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Kelvin: {CelsiusToKelvin(temperature)}");
                    break;
                case 4:
                    Console.Write("Enter temperature in Kelvin: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Celsius: {KelvinToCelsius(temperature)}");
                    break;
                case 5:
                    Console.Write("Enter temperature in Fahrenheit: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Kelvin: {FahrenheitToKelvin(temperature)}");
                    break;
                case 6:
                    Console.Write("Enter temperature in Kelvin: ");
                    temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Temperature in Fahrenheit: {KelvinToFahrenheit(temperature)}");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static double CelsiusToKelvin(double celsius)
    {
        return celsius + 273.15;
    }

    static double KelvinToCelsius(double kelvin)
    {
        return kelvin - 273.15;
    }

    static double FahrenheitToKelvin(double fahrenheit)
    {
        return CelsiusToKelvin(FahrenheitToCelsius(fahrenheit));
    }

    static double KelvinToFahrenheit(double kelvin)
    {
        return CelsiusToFahrenheit(KelvinToCelsius(kelvin));
    }


    public static void SimpleBankAccount()
    {
    }

    class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialBalance = 0)
        {
            balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}.");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}. New balance: {balance:C}.");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current balance: {balance:C}.");
        }
    }

    public partial class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount(100000);
            bool continueTransactions = true;

            while (continueTransactions)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine();
                decimal amount;

                switch (input)
                {
                    case "1":
                        Console.Write("Enter deposit amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out amount))
                        {
                            account.Deposit(amount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }

                        break;

                    case "2":
                        Console.Write("Enter withdrawal amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out amount))
                        {
                            account.Withdraw(amount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }

                        break;

                    case "3":
                        account.CheckBalance();
                        break;

                    case "4":
                        continueTransactions = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

    }


    public static void MorseCodeTraslator()
    {
        
    }

    private static readonly Dictionary<char, string> textToMorse = new Dictionary<char, string>
    {
        { 'A', ".-" }, { 'B', "-..." }, { 'C', "-.-." }, { 'D', "-.." }, { 'E', "." }, { 'F', "..-." },
        { 'G', "--." }, { 'H', "...." }, { 'I', ".." }, { 'J', ".---" }, { 'K', "-.-" }, { 'L', ".-.." },
        { 'M', "--" }, { 'N', "-." }, { 'O', "---" }, { 'P', ".--." }, { 'Q', "--.-" }, { 'R', ".-." },
        { 'S', "..." }, { 'T', "-" }, { 'U', "..-" }, { 'V', "...-" }, { 'W', ".--" }, { 'X', "-..-" },
        { 'Y', "-.--" }, { 'Z', "--.." }, { '0', "-----" }, { '1', ".----" }, { '2', "..---" },
        { '3', "...--" }, { '4', "....-" }, { '5', "....." }, { '6', "-...." }, { '7', "--..." },
        { '8', "---.." }, { '9', "----." }, { ' ', "/" }
    };

    private static readonly Dictionary<string, char> morseToText = new Dictionary<string, char>();

    static void MorseCodeTranslator()
    {
        foreach (var kvp in textToMorse)
        {
            morseToText[kvp.Value] = kvp.Key;
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Text to Morse Code");
            Console.WriteLine("2. Morse Code to Text");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter text to convert to Morse code:");
                    string text = Console.ReadLine().ToUpper();
                    string morse = TextToMorse(text);
                    Console.WriteLine($"Morse Code: {morse}");
                    break;
                case "2":
                    Console.WriteLine(
                        "Enter Morse code to convert to text (use spaces between Morse code characters):");
                    string morseCode = Console.ReadLine();
                    string textResult = MorseToText(morseCode);
                    Console.WriteLine($"Text: {textResult}");
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static string TextToMorse(string text)
    {
        List<string> morse = new List<string>();
        foreach (char c in text)
        {
            if (textToMorse.TryGetValue(c, out string code))
            {
                morse.Add(code);
            }
        }

        return string.Join(" ", morse);
    }

    static string MorseToText(string morse)
    {
        List<char> text = new List<char>();
        string[] morseCodes = morse.Split(' ');
        foreach (string code in morseCodes)
        {
            if (morseToText.TryGetValue(code, out char c))
            {
                text.Add(c);
            }
        }

        return new string(text.ToArray());
    }

    public static void RockPaperScissorsGame()
    {
        Random random = new Random();
        bool playAgain = true;
        string userChoice;
        string computerChoice;
        string answer;

        while (playAgain)
        {
            userChoice = "";
            computerChoice = "";
            answer = "";

            while (userChoice != "ROCK" && userChoice != "PAPER" && userChoice != "SCISSORS")
            {
                Console.Write("Enter ROCK, PAPER, or SCISSORS: ");
                userChoice = Console.ReadLine().ToUpper();
            }

            switch (random.Next(1, 4))
            {
                case 1:
                    computerChoice = "ROCK";
                    break;
                case 2:
                    computerChoice = "PAPER";
                    break;
                case 3:
                    computerChoice = "SCISSORS";
                    break;
            }

            Console.WriteLine("Computer: " + computerChoice);

            switch (userChoice)
            {
                case "ROCK":
                    if (computerChoice == "ROCK")
                    {
                        Console.WriteLine("It's a draw!");
                    }
                    else if (computerChoice == "PAPER")
                    {
                        Console.WriteLine("You lose!");
                    }
                    else
                    {
                        Console.WriteLine("You win!");
                    }
                    break;
                case "PAPER":
                    if (computerChoice == "PAPER")
                    {
                        Console.WriteLine("It's a draw!");
                    }
                    else if (computerChoice == "SCISSORS")
                    {
                        Console.WriteLine("You lose!");
                    }
                    else
                    {
                        Console.WriteLine("You win!");
                    }
                    break;
                case "SCISSORS":
                    if (computerChoice == "SCISSORS")
                    {
                        Console.WriteLine("It's a draw!");
                    }
                    else if (computerChoice == "ROCK")
                    {
                        Console.WriteLine("You lose!");
                    }
                    else
                    {
                        Console.WriteLine("You win!");
                    }
                    break;
            }

            Console.Write("Would you like to play again (Y/N): ");
            answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thanks for playing!");
    }

    public static void CsvParser()
    {
        static void Main(string[] args)
        {
            string filePath = "data.csv"; // Path to your CSV file
            List<string[]> csvData = ReadCsv(filePath);

            if (csvData.Count > 1)
            {
                string[] headers = csvData[0];
                List<double[]> numericData = ParseNumericData(csvData);

                for (int i = 0; i < headers.Length; i++)
                {
                    if (numericData[0][i] != double.MinValue) // Check if the column is numeric
                    {
                        double[] columnData = numericData.Select(row => row[i]).ToArray();
                        double average = columnData.Average();
                        double max = columnData.Max();
                        double min = columnData.Min();

                        Console.WriteLine($"{headers[i]} - Average: {average}, Max: {max}, Min: {min}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No data found in the CSV file.");
            }
        }

        static List<string[]> ReadCsv(string filePath)
        {
            List<string[]> csvData = new List<string[]>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(',');
                        csvData.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the CSV file: {ex.Message}");
            }

            return csvData;
        }

        static List<double[]> ParseNumericData(List<string[]> csvData)
        {
            List<double[]> numericData = new List<double[]>();
            string[] headers = csvData[0];

            for (int i = 1; i < csvData.Count; i++)
            {
                double[] rowData = new double[headers.Length];
                for (int j = 0; j < headers.Length; j++)
                {
                    if (double.TryParse(csvData[i][j], out double parsedValue))
                    {
                        rowData[j] = parsedValue;
                    }
                    else
                    {
                        rowData[j] = double.MinValue; // Mark non-numeric data
                    }
                }

                numericData.Add(rowData);
            }

            return numericData;
        }
    }

    public static void TaskManager()
    {
    }

    partial class Program
    {
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Task Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. List Tasks");
                Console.WriteLine("4. Mark Task as Complete");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ListTasks();
                        break;
                    case "4":
                        MarkTaskAsComplete();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            tasks.Add(new Task { Description = description, IsComplete = false });
            Console.WriteLine("Task added successfully.");
        }

        static void RemoveTask()
        {
            Console.Write("Enter the index of the task to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Task removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }

        static void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to display.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}. {tasks[i].Description} - {(tasks[i].IsComplete ? "Complete" : "Incomplete")}");
            }
        }

        static void MarkTaskAsComplete()
        {
            Console.Write("Enter the index of the task to mark as complete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
            {
                tasks[index].IsComplete = true;
                Console.WriteLine("Task marked as complete.");
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }
    }

    class Task
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    } }


    
  
    
    




    
    
    
    
    

