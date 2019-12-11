using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Book
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
        public void ShowStatistics()
        {
            System.Console.WriteLine($"Minimum grade = {grades.Max()}");
            Console.WriteLine($"Maximum grade = {grades.Min()}");
            Console.WriteLine($"Average grade ={grades.Average()}");
        }
        List<double> grades;
        string name;
    }
}