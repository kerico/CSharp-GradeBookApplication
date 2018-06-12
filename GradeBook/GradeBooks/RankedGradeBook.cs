using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count<5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            var gradingStep = (int)Math.Ceiling(grades.Count * 0.2);

            if (grades[gradingStep-1]<=averageGrade)
                return 'A';
            else if (grades[(gradingStep * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(gradingStep * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(gradingStep * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count<5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            else
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
