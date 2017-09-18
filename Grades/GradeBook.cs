using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class GradeBook
    {
        public GradeBook()
        {
            grades = new List<float>();
        }

        // methods are a member of this class
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
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

        //a "field" for storing a list of floating point numbers
        //be sure to initialize, otherwise you get null reference error
        //List<float> grades = new List<float>();
        // Don't need to write it like above since we made a GradeBook class w/grade declaration
        private List<float> grades;

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