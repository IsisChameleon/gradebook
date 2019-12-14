using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double Grade);
        Statistics GetStatistics();
        string Name { get;}
        event GradeAddedDelegate GradeAdded;
        
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double Grade);
        public abstract Statistics GetStatistics();

        public void CheckGradeIsValid(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name, string dirPath) : base(name)
        {
            // initialise filename with path and book name 

            bool  exist = Directory.Exists(dirPath);

            if (exist)
            { 
                this.filename = dirPath + Path.DirectorySeparatorChar + this.Name + ".txt";
                using (var fS = new StreamWriter(this.filename, true))
                {
                }
            }
            // we need to be able to open the file for append

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double Grade)
        {
            CheckGradeIsValid(Grade);
            AddGradeToFile(Grade);
        }

        private void AddGradeToFile(double grade)
        {
            // Saving the grade to new file
            // open file
            using (var fS = new StreamWriter(this.filename, true))
            {
                // append to file with "true" as second parameter
                fS.WriteLine($"{grade}");
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

        }
        public override Statistics GetStatistics()
        //
        // Summary:
        //     Initializes a new instance of the System.IO.StreamReader class for the specified
        //     stream, with the specified byte order mark detection option.
        {
            string[] lines = System.IO.File.ReadAllLines(this.filename);
            List<double> grades = lines.Select(x => double.Parse(x)).ToList();
            var result = new Statistics(grades);

            return result;

        }

        string filename;
    }
    public class InMemoryBook : Book
    {

        public InMemoryBook(string name) : base(name)      //accessing constructor of base class
        {
            grades = new List<double>();
            //Name = name;   // the name has been set in the base class NamedObject
        }
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)   // This is the method that implements AddGrade from the base abstract class 
                                                      // this is clear thanks to the override keywords
                                                      // you can only override abstract and virtual methods
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            else
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    // that means someone put a function pointer into GradeAdded to be called when Grade is added
                    // Note that GradeAdded has been defined as a public event GradeAddedDelegate GradeAdded; 
                    // so it's an "event" 
                    GradeAdded(this, new EventArgs());
                }
            }

        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics(grades);

            // if (grades.Count == 0)
            // {
            //     return result;
            // }

            // result.High = grades.Max();
            // result.Low = grades.Min();
            // result.Average = grades.Average();

            // switch (result.Average)
            // {
            //     case var d when d >= 90:
            //         result.Letter='A';
            //         break;
            //     case var d when d >= 80:
            //         result.Letter='B';
            //         break;
            //     case var d when d >= 70:
            //         result.Letter='C';
            //         break;
            //     case var d when d >= 60:
            //         result.Letter='D';
            //         break;
            //     default:
            //         result.Letter='F';
            //         break;
            // }

            return result;
        }

        List<double> grades;
        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {   
        //         if (!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
        //     }
        // }
        // private string name;

        public override event GradeAddedDelegate GradeAdded;

        // because this function pointer is an "event" that means one can just add to it, not assign it
        // that is great because that means no one can turn up and delete what others have put on the function pointer
        // they can just add to it

        public const string CATEGORY = "Science";

    }
};