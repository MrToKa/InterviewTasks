using System.Text;

namespace Calculator
{
    class Program
    {
        public static string ShowMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Enter 'A' for addition.");
            sb.AppendLine("Enter 'S' for subtraction.");
            sb.AppendLine("Enter 'M' for multiplication.");
            sb.AppendLine("Enter 'D' for division.");
            sb.AppendLine("Enter 'Q' to quit the program.");

            return sb.ToString();
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public static double ReadNumber(string input)
        {
            double num;
            while (true)
            {
                Console.WriteLine(input);
                if (double.TryParse(Console.ReadLine(), out num))
                {
                    return num;
                }

                Console.WriteLine("Invalid number. Please try again.");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(ShowMenu());

            while (true)
            {
                char command = Console.ReadLine()[0];

                if (command == 'Q')
                {
                    break;
                }

                double a;
                double b;

                switch (command)
                {
                    case 'A':
                        a = ReadNumber("Enter the first number: ");
                        b = ReadNumber("Enter the second number: ");
                        Console.WriteLine($"The result is: {Add(a, b)}");
                        break;
                    case 'S':
                        a = ReadNumber("Enter the first number: ");
                        b = ReadNumber("Enter the second number: ");
                        Console.WriteLine($"The result is: {Subtract(a, b)}");
                        break;
                    case 'M':
                        a = ReadNumber("Enter the first number: ");
                        b = ReadNumber("Enter the second number: ");
                        Console.WriteLine($"The result is: {Multiply(a, b)}");
                        break;
                    case 'D':
                        a = ReadNumber("Enter the first number: ");
                        b = ReadNumber("Enter the second number: ");
                        if (b == 0)
                        {
                            Console.WriteLine("Cannot divide by zero.");
                            break;
                        }
                        Console.WriteLine($"The result is: {Divide(a, b)}");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine(ShowMenu());
            }
        }
    }
}