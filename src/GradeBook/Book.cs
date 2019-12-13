using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class Book
    {

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(char letter)
        {
            switch(letter)
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
        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            else
            {
                grades.Add(grade);
                if (GradeAdded!=null)
                {
                    // that means someone put a function pointer into GradeAdded to be called when Grade is added
                    // Note that GradeAdded has been defined as a public event GradeAddedDelegate GradeAdded; 
                    // so it's an "event" 
                    GradeAdded(this, new EventArgs());
                }
            }
            
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.High = grades.Max();
            result.Low = grades.Min();
            result.Average = grades.Average();

            switch(result.Average)
            {
                case var d when d >= 90:
                    result.Letter='A';
                    break;
                case var d when d >= 80:
                    result.Letter='B';
                    break;
                case var d when d >= 70:
                    result.Letter='C';
                    break;
                case var d when d >= 60:
                    result.Letter='D';
                    break;
                default:
                    result.Letter='F';
                    break;
            }

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

        public event GradeAddedDelegate GradeAdded;
        // because this function pointer is an "event" that means one can just add to it, not assign it
        // that is great because that means no one can turn up and delete what others have put on the function pointer
        // they can just add to it

        public string Name
        {
            get; 
            private set;  // Can only set it from inside Book.cs code
        }

        public const string CATEGORY = "Science";
    
    }
};