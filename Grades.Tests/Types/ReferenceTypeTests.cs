using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            //grades = new float[5]; // this would break test since it's a new array, not the one above
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "bryan";
            //name.ToUpper();
            //Assert.AreEqual("BRYAN", name); //false, behaves like a value type even though its a reference type

            name = name.ToUpper();
            Assert.AreEqual("BRYAN", name); //true
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);

            // date.AddDays(1); // this constructs a new datetime date variable
            // Assert.AreEqual(2, date.Day); //false

            date = date.AddDays(1);
            Assert.AreEqual(2, date.Day); // true
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);
            Assert.AreEqual(46, x); //true, because "number" arg is a copy of the number
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book1);
            Assert.AreEqual(book1.Name, book2.Name); //true
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A grade book";
        }


        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Bryan";
            string name2 = "bryan";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result); //true
        }


        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1,x2); // True
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "bryan";

            Assert.AreEqual(g1.Name, g2.Name); // True

            //versus

            //GradeBook g1 = new GradeBook();
            //GradeBook g2 = g1;

            //g1 = new GradeBook()
            //g1.Name = "bryan";
            //Console.WriteLine(g2.Name); //output "" bc pointing to a new G
        }
    }
}
