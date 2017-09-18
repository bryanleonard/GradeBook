using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f); //f allows it to convert to a float
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);


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