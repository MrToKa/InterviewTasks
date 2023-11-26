namespace SvilengradCasino
{
    internal class Validations
    {
        public static int CheckIntInput(string message)
        {
            Console.WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return CheckIntInput(message);
            }
        }

        public static string CheckStringInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                input = Console.ReadLine();
            }

            return input;
        }

        public static DateTime CheckDateTimeInput(string message)
        {
            bool isDateTime = DateTime.TryParse(CheckStringInput(message), out DateTime result);
            while (true)
            {
                if (isDateTime)
                {
                    return result;
                }

                Console.WriteLine("Invalid input");
                isDateTime = DateTime.TryParse(CheckStringInput(message), out result);
            }
        }

        public static bool CheckBoolInput(string message)
        {
            bool isBool = bool.TryParse(CheckStringInput(message), out bool result);
            while (true)
            {
                if (isBool)
                {
                    return result;
                }

                Console.WriteLine("Invalid input");
                isBool = bool.TryParse(CheckStringInput(message), out result);
            }
        }

        public static double CheckDoubleInput(string message)
        {
            bool isDouble = double.TryParse(CheckStringInput(message), out double result);
            while (true)
            {
                if (isDouble)
                {
                    return result;
                }

                Console.WriteLine("Invalid input");
                isDouble = double.TryParse(CheckStringInput(message), out result);
            }
        }

        public static decimal CheckDecimalInput(string message)
        {
            bool isDecimal = decimal.TryParse(CheckStringInput(message), out decimal result);
            while (true)
            {
                if (isDecimal)
                {
                    return result;
                }

                Console.WriteLine("Invalid input");
                isDecimal = decimal.TryParse(CheckStringInput(message), out result);
            }
        }

    }
}
