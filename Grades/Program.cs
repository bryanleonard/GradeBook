using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static IGradeTracker CreateGradeBook() //abstracted factory fn allows for polymorphism
        {
            return new GradeBook();
            // or return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            // "using" closes and/or disposes for proper handling.
            // references IDsiposable
            using (StreamWriter outputFile = File.CreateText("grades.txt")) 
            {
                book.WriteGrades(outputFile);
            }

            //book.WriteGrades(Console.Out);
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f); //f allows it to convert to a float
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void WriteResult(string desc, float result) //must be static bc it's invoked from a static method
        {
            Console.WriteLine($"{desc}: {result:F2}");
        }

        private static void WriteResult(string desc, string result) //must be static bc it's invoked from a static method
        {
            Console.WriteLine($"{desc}: {result}");
        }
    }
}

//access modifiers - start there.
// public - makes a class memember publicly available. 
// private - (default) only usable from code insie of the same class

// static - use static class members t/o creating an instance
// for example: public static float MinGrade = 0;   // GradeBook.MinGrade;
//              public static float MaxGrade = 100; // GradeBook.MaxGrade;