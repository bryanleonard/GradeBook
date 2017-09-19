using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args); // object allows anything to be passed (int, str, GradeBook instance, etc.)
}
