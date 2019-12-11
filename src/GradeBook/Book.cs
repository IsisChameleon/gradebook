using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.High = grades.Max();
            result.Low = grades.Min();
            result.Average = grades.Average();

            return result;
        }
        List<double> grades;
        string name;
    }
}