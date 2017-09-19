using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker //without : IGradeTracker, we would use the Abstract GradeTracker Class
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        // Assumng all of the below functionality will exist largely unchanged through the entire program.
        // ***************************************************************************************************

        //public string Name;
        //public string Name { get; set; } // works same as above but makes it a Property instead of a Field
        public string Name // prevents null setting, unlike above
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty");
                }

                // insert a delegate/event to announce name change
                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    NameChanged(this, args); // this references the object sender
                }
                _name = value;

            }
        }

        //delegate stuff (pub/sub)
        //public NameChangedDelegate NameChanged; //delegate version
        public event NameChangedDelegate NameChanged;

        protected string _name;
    }
}
