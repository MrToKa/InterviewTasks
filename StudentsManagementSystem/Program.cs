using System.Text;
using System.Text.RegularExpressions;

namespace StudentsManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine(Menu());

                string input = Console.ReadLine();

                int rollNum;

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Please enter Name, Roll number and GPA");
                        string name = ReadName();
                        rollNum = ReadRollNumber("Enter a Roll number: ");

                        if (RollNumExist(rollNum, students))
                        {
                            Console.WriteLine("Duplicated roll number. Please enter a different Roll number.");
                            rollNum = ReadRollNumber("Enter a Roll number: ");
                        }

                        double gpa = ReadGPA("Enter a GPA: ");

                        Student student = new Student(name, rollNum, gpa);

                        Console.WriteLine($"Student {student.Name} with roll number {student.RollNumber} and GPA {student.GPA:F2} was added to the system.");

                        students.Add(student);
                        break;
                    case "2":
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Students in class:");
                        foreach (var participantStudent in students)
                        {
                            sb.AppendLine($"{participantStudent.Name} with roll number {participantStudent.RollNumber} has GPA {participantStudent.GPA:F2}");
                        }
                        Console.WriteLine(sb.ToString());
                        break;
                    case "3":
                        rollNum = ReadRollNumber("Please enter a Roll number: ");
                        Student searchedStudent = students.Find(x => x.RollNumber == rollNum);
                        if (searchedStudent != null)
                        {
                            Console.WriteLine($"{searchedStudent.Name} with roll number {searchedStudent.RollNumber} has GPA {searchedStudent.GPA:F2}");
                        }
                        else
                        {
                            Console.WriteLine($"No student with Roll number {rollNum} was found!");
                        }
                        break;
                    case "4":
                        double averageGrade = students.Average(x => x.GPA);
                        Console.WriteLine($"Average GPA of the class is {averageGrade:F2}");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid input! Please choose a number from 1 to 5");
                        break;
                }
            }
        }

        private static bool RollNumExist(int rollNum, List<Student> studentsList)
        {
            return studentsList.Exists(x => x.RollNumber == rollNum);
        }

        public static string ReadName()
        {
            while (true)
            {
                Console.WriteLine("Enter a name: ");
                string name = Console.ReadLine();
                Regex regex = new Regex(@"^([a-zA-Z]+[_\s-]*)+$");

                if (!regex.IsMatch(name))
                {
                    name = "";
                }

                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }

                Console.WriteLine("Invalid name. Please enter a valid name.");
            }
        }
        public static int ReadRollNumber(string input)
        {
            while (true)
            {
                Console.WriteLine(input);
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (num >= 1) return num;
                }

                Console.WriteLine("Invalid Roll number. Please enter a valid Roll number.");
            }
        }        
        
        public static double ReadGPA(string input)
        {
            while (true)
            {
                Console.WriteLine(input);
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    if (num is >= 0.0 and <= 100.0) return num;
                }

                Console.WriteLine("Invalid grade. Please enter a valid GPA score.");
            }
        }

        public static string Menu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Choose an option:");
            sb.AppendLine("1 - Add Student");
            sb.AppendLine("2 - View Students");
            sb.AppendLine("3 - Search Student by Roll Number");
            sb.AppendLine("4 - Calculate Average GPA");
            sb.AppendLine("5 - Exit");
            return sb.ToString();
        }
    }

    public class Student
    {
        public Student()
        {
            
        }

        public Student(string name, int rollNum, double gpa)
        {
            Name = name;
            RollNumber = rollNum;
            GPA = gpa;
        }

        public string Name { get; set; }

        public int RollNumber { get; set; }

        public double GPA { get; set; }
    }
}