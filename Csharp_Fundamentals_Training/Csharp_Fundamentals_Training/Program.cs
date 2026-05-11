using System.Diagnostics;

namespace Csharp_Fundamentals_Training
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int score = Convert.ToInt32(Console.ReadLine()); // This Line Takes The Score From The User.

            char grade; // This Line Is An Empty Variable.

            if (score >= 90 && score <= 100) // This Line Check The Score If It Is From 90 to 100.
            {
                grade = 'A'; // Assign The Character To Variable Grade
            }

            else if (score >= 80 && score <= 89) // This Line Check The Score If It Is From 80 to 89.
            {
                grade = 'B'; // Assign The Character To Variable Grade
            }

            else if (score >= 70 && score <= 79) // This Line Check The Score If It Is From 70 to 79.
            {
                grade = 'C'; // Assign The Character To Variable Grade
            }

            else if (score >= 60 && score <= 69) // This Line Check The Score If It Is From 60 to 69.
            {
                grade = 'D'; // Assign The Character To Variable Grade
            }

            else if (score >= 0 && score <= 59) // This Line Check The Score If It Is From 0 to 59.
            {
                grade = 'F'; // Assign The Character To Variable Grade
            }

            else
            {

                grade = 'R'; // I Put This Line If The User Enters A Number Less Than 0.
            }

            switch (grade)
            {
                case 'A': //This Line If The Grade Is A
                    Console.WriteLine("Excelent"); // Print The Output As An Excelent
                    break;

                case 'B':
                    Console.WriteLine("Very Good"); // Print The Output As An Very Good
                    break;

                case 'C':
                    Console.WriteLine("Good"); // Print The Output As An Good
                    break;

                case 'D':
                    Console.WriteLine("Pass"); // Print The Output As An Pass
                    break;

                case 'F':
                    Console.WriteLine("Fail"); // Print The Output As An Fail
                    break;

                default:
                    Console.WriteLine("Invalid Student Score"); // Print The Output As An Invalid Student Score Because The User Entered Score Less Than Zero.
                    break;
            }
        }
    }
}