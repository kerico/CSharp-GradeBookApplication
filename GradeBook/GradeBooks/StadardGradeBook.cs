using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class StadardGradeBook : BaseGradeBook
    {
        public StadardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }
    }
}
