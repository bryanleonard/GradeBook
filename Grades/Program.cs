using System;
using System.Collections.Generic;
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

            GradeBook book = new GradeBook();

            book.NameChanged += OnNameChanged; //shorthand
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2); // would take existing and add additional delegate
            // but delegates are susceptible to veing easily overwritten ie, book.NameChanged = null; so use an event

            book.Name = "Bryan's Grade Book";
            //book.Name = "B-Dazzle's Grade Book"; // NameChangedDelegate would fire each time it's changed
            book.AddGrade(91);
            book.AddGrade(89.5f); //f allows it to convert to a float
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade); //type coercison or cast
            WriteResult("Lowest", stats.LowestGrade);

        }

        static void WriteResult(string desc, float result) //must be static bc it's invoked from a static method
        {
            Console.WriteLine(desc + ": " + result); 
        }

        static void WriteResult(string desc, int result) //must be static bc it's invoked from a static method
        {
            //Console.WriteLine("{0}: {1}", desc, result); //search C# string formatting options
            Console.WriteLine($"{desc}: {result}", desc, result);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}.");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"***");
        }

    }
}

//https://app.pluralsight.com/player?course=c-sharp-fundamentals-with-visual-studio-2015&author=scott-allen&name=c-sharp-fundamentals-with-visual-studio-2015-m3&clip=4&mode=live

//access modifiers - start there.
// public - makes a class memember publicly available. 
// private - (default) only usable from code insie of the same class

// static - use static class members t/o creating an instance
// for example: public static float MinGrade = 0;   // GradeBook.MinGrade;
//              public static float MaxGrade = 100; // GradeBook.MaxGrade;