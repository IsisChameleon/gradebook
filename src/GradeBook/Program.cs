using System;  // Console is inside System namepspace 
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Book mygradebook = new Book("My First Gradebook");
            mygradebook.AddGrade(56.8);
            mygradebook.AddGrade(12.7);
            mygradebook.AddGrade(6.11);
            mygradebook.AddGrade(4);
            mygradebook.AddGrade(37.2);
           
            // var numbers = new double[3];
            // // numbers[0] = 12.7;
            // // numbers[1] = 10.3;
            // // numbers[2] = 6.11;

            var numbers = new[] {12.7, 10.3, 6.11, 4.1};
            // List<double> grades = new List<double>();
            var grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            // List provides a dynamically sized collection of items
            grades.Add(56.1);

            double result = 0;
            foreach (var i in numbers)
            {
                result+=i;
            }
            Console.WriteLine($"result : {result}");

            double result2 = 0;
            foreach (var i in grades)
            {
                result2+=i;
            }
            Console.WriteLine($"result2 : {result2:N1}");  

            double average = grades.Count > 0 ? grades.Average() : double.NaN;  

            Console.WriteLine($"Avergae results2 : {average}"); 

            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine("hello bobo");
            }
        }
    }
}
