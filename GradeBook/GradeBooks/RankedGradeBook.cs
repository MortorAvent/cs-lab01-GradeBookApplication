using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("The minimum number of students is 5");
            }
     
            int top20PercentCount = (int)Math.Ceiling(Students.Count * 0.2);
            
            List<double> grades = new List<double>();
            foreach (Student student in Students)
            {
                grades.Add(student.AverageGrade);
            }

            grades.Sort();
            grades.Reverse();
            
            int index = grades.IndexOf(averageGrade);

            if (index < top20PercentCount)
            {
                return 'A';
            }
            else if (index < top20PercentCount * 2)
            {
                return 'B';
            }
            else if (index < top20PercentCount * 3)
            {
                return 'C';
            }
            else if (index < top20PercentCount * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if(Students.Count <5)
            {
                Console.WriteLine("Ranked grading requires a least 5 students");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

    }
}
