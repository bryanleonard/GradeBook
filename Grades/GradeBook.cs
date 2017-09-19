using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // adding public keyword for unit tests
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Bree-yon"; // just to envoke the NameChanged delegate
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

        //public string Name;
        //public string Name { get; set; } // works same as above but makes it a Property instead of a Field
        public string Name // prevents null setting, unlike above
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    // insert a delegate to announce name change
                    if (_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;
                        NameChanged(this, args); // this references the object sender
                    }
                    _name = value;
                }
            }
        }

        private string _name;

        // so since Name is publicly accessible and can be changed externally, we make it a property
        // but grades List is private to this class and we dont' want it changed externally.


        // delegate stuff (think pub/sub)
        //public NameChangedDelegate NameChanged;
        //makes the delegate an event! Preferred
        public event NameChangedDelegate NameChanged; 
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