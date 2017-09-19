using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // adding public keyword for unit tests
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "Bryan's Grade Book of Stuff"; // just to envoke the NameChanged delegate/event
            grades = new List<float>();
        }

        // methods are a member of this class
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics() //virtual allows for polymorphism (uses type of object, not type of variable)
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        //A "field" for storing a list of floating point numbers
        //be sure to initialize, otherwise you get null reference error
        //List<float> grades = new List<float>();
        //Don't need to write it like above since we made a GradeBook class w/grade declaration
        protected List<float> grades; //protected (instead of private) gives us access inside ThrowAwayGrades since it inherits

        // not sure what this is all about...
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        public override void WriteGrades(TextWriter destination) //TextWriter is a useful abstraction, (file, console, over the net, etc.)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }
    }
}

//Class Members Define
// 1. State (nouns)
// 2. Behavior (verbs)

// GradeBook State
// 1. The grades for a user

// GradeBook Behavior
// 1. Add a new grade
// 2. Calculate stats