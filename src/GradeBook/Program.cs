using System;  // Console is inside System namepspace 
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
           
            Console.WriteLine("Please enter the name of the book.");
            input = Console.ReadLine();
            Book mygradebook = new Book(input);
            mygradebook.GradeAdded += OnGradeAdded; // GradeAdded function pointer is set
            mygradebook.GradeAdded += OnGradeAdded;
            mygradebook.GradeAdded -= OnGradeAdded;
            mygradebook.GradeAdded += OnGradeAdded; // on event GradeAdded we want to call function OnGradeAdded twice in total
            mygradebook.GradeAdded = null;
            
            while(true)
            {
                Console.WriteLine("Please enter a grade or q to quit!.");
                input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try 
                {
                    var grade = double.Parse(input);
                    mygradebook.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Executed before exiting whether I did throw an exception or not");
                }

            };

            var result = mygradebook.GetStatistics();

            Console.WriteLine($". For the Book : {mygradebook.Name}");
            Console.WriteLine($". For the Book : {Book.CATEGORY}");
            Console.WriteLine($". Average actual : {result.Average}");
            Console.WriteLine($"High actual : {result.High}");
            Console.WriteLine($"Low actual : {result.Low}");
            Console.WriteLine($"Letter : {result.Letter}");

            // Book mygradebook = new Book("My First Gradebook");
            // mygradebook.AddGrade(56.8);
            // mygradebook.AddGrade(12.7);
            // mygradebook.AddGrade(6.11);
            // mygradebook.AddGrade(4);
            // mygradebook.AddGrade(37.2);
           
            // var numbers = new double[3];
            // // numbers[0] = 12.7;
            // // numbers[1] = 10.3;
            // // numbers[2] = 6.11;

            var numbers = new[] {12.7, 10.3, 6.11, 4.1};
            // List<double> grades = new List<double>();
            var grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            // List provides a dynamically sized collection of items
            grades.Add(56.1);

            double r = 0;
            foreach (var i in numbers)
            {
                r+=i;
            }
            Console.WriteLine($"result : {r}");

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

        static void OnGradeAdded(object sender, EventArgs e) => Console.WriteLine($"A grade was added .. ");
    }
}
