using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "That's great!";
                        break;

                    case "B":
                        result = "You're swell!";
                        break;

                    case "C":
                        result = "I hope you like community college.";
                        break;

                    case "D":
                        result = "I hope you like mopping floors at community college.";
                        break;

                    default :
                        result = "Yes, I'll want fries with that.";
                        break;
                }

                return result;
            }
        }

        public string LetterGrade
        {
            // no set means it can't be changed :)
            get
            {
                string result;
                if (AverageGrade >= 90)
                {
                    result = "A";
                }
                else if (AverageGrade >= 80)
                {
                    result = "B";
                }
                else if (AverageGrade >= 70)
                {
                    result = "C";
                }
                else if (AverageGrade >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }

                return result;
            }
        }

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}
