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

            // Implementation of DiskBook
            // ===========================

            var gb = new DiskBook(input,".");
            gb.GradeAdded += OnGradeAdded;

            input = EnterGrades(gb);

            var result = gb.GetStatistics();

            Console.WriteLine("Implementation of DiskBook -----------------");
            Console.WriteLine($". For the Book : {gb.Name}");
            Console.WriteLine($". Average actual : {result.Average}");
            Console.WriteLine($"High actual : {result.High}");
            Console.WriteLine($"Low actual : {result.Low}");
            Console.WriteLine($"Letter : {result.Letter}");


            // Implementation of In MemoryBook
            //================================


            InMemoryBook mygradebook = new InMemoryBook(input);
            mygradebook.GradeAdded += OnGradeAdded; // GradeAdded function pointer is set
            mygradebook.GradeAdded += OnGradeAdded;
            mygradebook.GradeAdded -= OnGradeAdded;
            mygradebook.GradeAdded += OnGradeAdded; // on event GradeAdded we want to call function OnGradeAdded twice in total
            /// mygradebook.GradeAdded = null; we cannot do that because GradeAdded is a "event" function pointer

            input = EnterGrades(mygradebook);

            var result2 = mygradebook.GetStatistics();

            Console.WriteLine("Implementation of InMemoryBook -----------------");
            Console.WriteLine($". For the Book : {mygradebook.Name}");
            Console.WriteLine($". For the Book : {InMemoryBook.CATEGORY}");
            Console.WriteLine($". Average actual : {result2.Average}");
            Console.WriteLine($"High actual : {result2.High}");
            Console.WriteLine($"Low actual : {result2.Low}");
            Console.WriteLine($"Letter : {result2.Letter}");

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

            var numbers = new[] { 12.7, 10.3, 6.11, 4.1 };
            // List<double> grades = new List<double>();
            var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            // List provides a dynamically sized collection of items
            grades.Add(56.1);

            double r = 0;
            foreach (var i in numbers)
            {
                r += i;
            }
            Console.WriteLine($"result : {r}");

            double result3 = 0;
            foreach (var i in grades)
            {
                result3 += i;
            }
            Console.WriteLine($"result3 : {result3:N1}");

            double average = grades.Count > 0 ? grades.Average() : double.NaN;

            Console.WriteLine($"Avergae results3 : {average}");

            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine("hello bobo");
            }
        }

        private static string EnterGrades(IBook mygradebook)
        {
            string input;
            while (true)
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Executed before exiting whether I did throw an exception or not");
                }

            };
            return input;
        }

        static void OnGradeAdded(object sender, EventArgs e) => Console.WriteLine($"A grade was added .. ");
    }
}
